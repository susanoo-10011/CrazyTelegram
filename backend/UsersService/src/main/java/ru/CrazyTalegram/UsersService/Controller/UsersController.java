package ru.CrazyTalegram.UsersService.Controller;

import ru.CrazyTalegram.UsersService.Model.RequestEntities.LoginRequest;
import ru.CrazyTalegram.UsersService.Model.RequestEntities.RegistrationRequest;
import lombok.AllArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import ru.CrazyTalegram.UsersService.Service.IUserService;


@RestController
@RequestMapping("/api/v1/users")
@AllArgsConstructor
public class UsersController {

    private final IUserService _userService;

    @PostMapping("/registration")
    public ResponseEntity<?> saveUser(@RequestBody RegistrationRequest user) {
        return  _userService.saveUser(user);
    }

    @PostMapping("/login")
    public ResponseEntity<?> logInSystem(@RequestBody LoginRequest user) {
        return _userService.logInToSystem(user);
    }

    @DeleteMapping("/logOut")
    public ResponseEntity<?> logOutFromSystem(@RequestHeader("X-User-Agent") String header) {
        return _userService.logOutFromSystem(header);
    }
}