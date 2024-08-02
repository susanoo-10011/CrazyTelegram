package ru.CrazyTalegram.UsersService.Model.RequestEntities;

import lombok.Data;

@Data
public class LoginRequest {

    String email;
    String password;
}
