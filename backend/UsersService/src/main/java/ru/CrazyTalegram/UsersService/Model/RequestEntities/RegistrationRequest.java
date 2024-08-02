package ru.CrazyTalegram.UsersService.Model.RequestEntities;

import lombok.Data;

@Data
public class RegistrationRequest {

    String username;
    String email;
    String password;

}
