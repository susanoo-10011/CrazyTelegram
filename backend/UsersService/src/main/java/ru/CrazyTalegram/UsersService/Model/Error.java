package ru.CrazyTalegram.UsersService.Model;

import lombok.Data;
import org.springframework.http.HttpStatus;

@Data
public class Error {

   public Integer status;
   public String message;
   public HttpStatus error;
}
