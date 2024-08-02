package ru.CrazyTalegram.UsersService.Service;

import ru.CrazyTalegram.UsersService.Model.RequestEntities.LoginRequest;
import ru.CrazyTalegram.UsersService.Model.RequestEntities.RegistrationRequest;
import ru.CrazyTalegram.UsersService.Model.DatabaseEntities.TokenRecord;
import org.springframework.http.ResponseEntity;

public interface IUserService {

    ResponseEntity<?> saveUser(RegistrationRequest user);

    ResponseEntity<TokenRecord> logInToSystem(LoginRequest user);

    ResponseEntity<?> logOutFromSystem(String token);

}