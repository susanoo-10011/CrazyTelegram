package ru.CrazyTalegram.UsersService.Exceptions;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Getter;
import ru.CrazyTalegram.UsersService.Model.Error;

@Getter
public class CustomException extends RuntimeException {

    @JsonProperty("status")
    private int statusCode;

    @JsonProperty("error")
    private Error error;

    public CustomException(Error error) {

        statusCode = error.status;
        this.error = error;
    }
}