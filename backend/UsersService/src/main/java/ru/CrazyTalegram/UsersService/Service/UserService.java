package ru.CrazyTalegram.UsersService.Service;

import ru.CrazyTalegram.UsersService.Exceptions.CustomException;
import ru.CrazyTalegram.UsersService.Model.DatabaseEntities.TokenRecord;
import ru.CrazyTalegram.UsersService.Model.Error;
import ru.CrazyTalegram.UsersService.Model.RequestEntities.LoginRequest;
import ru.CrazyTalegram.UsersService.Model.RequestEntities.RegistrationRequest;
import ru.CrazyTalegram.UsersService.Model.DatabaseEntities.User;
import ru.CrazyTalegram.UsersService.Repository.IUserRepository;
import ru.CrazyTalegram.UsersService.Repository.IUserTokenRepository;
import lombok.AllArgsConstructor;
import org.springframework.context.annotation.Primary;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.lang.Nullable;
import org.springframework.stereotype.Service;
import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.transaction.annotation.Transactional;
import java.time.LocalDateTime;
import java.util.*;

@Service
@AllArgsConstructor
@Primary
@Transactional
public class UserService implements IUserService{

    private final IUserRepository _userRepository;
    private final IUserTokenRepository _tokenRepository;

    @Override
    public ResponseEntity<?> saveUser(RegistrationRequest request) {

        User user = new User();
        user.setUsername(request.getUsername());
        user.setPassword(request.getPassword());
        user.setEmail(request.getEmail());

        CheckIncomingParametersToCreateUser(user);

        try {
            User savedUser = _userRepository.save(user);

            return new ResponseEntity<>(HttpStatus.OK);
        } catch (DataIntegrityViolationException e) {
            throw new CustomException(generateError("Invalid request", HttpStatus.BAD_REQUEST));
        } catch (Exception e) {
            throw new CustomException(generateError("Failed to save user", HttpStatus.INTERNAL_SERVER_ERROR));
        }
    }

    @Override
    public ResponseEntity<TokenRecord> logInToSystem(LoginRequest user) {

        User foundUser = _userRepository.findUserByEmail(user.getEmail());

        checkLoginPasswordLogInSystem(foundUser);

        TokenRecord token = createToken(foundUser);

        try {
            _tokenRepository.save(token);

            return new ResponseEntity<>(token, HttpStatus.OK);
        } catch (DataIntegrityViolationException e) {
            throw new CustomException(generateError("Invalid request", HttpStatus.BAD_REQUEST));
        } catch (Exception e) {
           throw new CustomException(generateError("Failed to save user", HttpStatus.INTERNAL_SERVER_ERROR));
        }
    }

    @Override
    public ResponseEntity<?> logOutFromSystem(String token) {

        TokenRecord foundToken = _tokenRepository.findByTokenValue(token);
        if(foundToken == null){
           throw new CustomException(generateError("User not found", HttpStatus.NOT_FOUND));
        }

        try{
            _tokenRepository.deleteByTokenValue(token);
            return new ResponseEntity<>(HttpStatus.OK);
        }
        catch (DataIntegrityViolationException e) {
            throw new CustomException(generateError("Failed to delete token", HttpStatus.CONFLICT));
        }
        catch(Exception e){
            throw new CustomException(generateError("Failed to delete token", HttpStatus.INTERNAL_SERVER_ERROR));
        }
    }

    private void checkLoginPasswordLogInSystem(User user) {


        if (user == null) {
            throw new CustomException(generateError("User not found", HttpStatus.NOT_FOUND));
        }

        if (!user.getPassword().equals(user.getPassword())) {
            throw new CustomException(generateError("Wrong password", HttpStatus.UNAUTHORIZED));
        }
    }

    private TokenRecord createToken(User user){

        if(user.getId() == null){
            user = _userRepository.findUserByUsername(user.getUsername());
        }

        String token = UUID.randomUUID().toString();

        TokenRecord tokenRecord = new TokenRecord();
        tokenRecord.setUser(user);
        tokenRecord.setTokenValue(token);
        tokenRecord.setCreatedDate(LocalDateTime.now());
        tokenRecord.setExpirationDate(LocalDateTime.now().plusMonths(1));

        return tokenRecord;
    }

    @Nullable
    private String checkPassword(String password){
        String message = null;

        if (password.length() < 8) {
            message = "Password must be at least 8 characters long";
        }

        if (!password.matches("^(?=.*[!@#$%^&*(),.?\":{}|<>]).*$")) {
            message = "Password must contain special characters";
        }

        return message;
    }

    @Nullable
    private String checkEmail(String email){
        if (!email.matches("^[A-Za-z0-9+_.-]+@[A-Za-z0-9.-]+$")) {
            return "Invalid email format";
        }
        else return null;
    }

    private void CheckIncomingParametersToCreateUser(User user) {
        String messageCheckPassword = checkPassword(user.getPassword());
        if (messageCheckPassword != null) {
            throw new CustomException(generateError(messageCheckPassword, HttpStatus.BAD_REQUEST));
        }

        String messageCheckEmail = checkEmail(user.getEmail());
        if(messageCheckEmail != null){
            throw new CustomException(generateError(messageCheckEmail, HttpStatus.BAD_REQUEST));
        }

        User existingUser = _userRepository.findUserByEmail(user.getEmail());
        if(existingUser != null){
            throw new CustomException(generateError("User with this email already exists", HttpStatus.CONFLICT));
        }
    }

    private Error generateError(String message, HttpStatus status) {

        Error error = new Error();
        error.setMessage(message);
        error.setStatus(status.value());

        return error;
    }
}