package ru.CrazyTalegram.MessageServer.Controllers;


import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.messaging.handler.annotation.MessageMapping;
import org.springframework.messaging.handler.annotation.Payload;
import org.springframework.messaging.handler.annotation.SendTo;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import ru.CrazyTalegram.MessageServer.Model.MongoDBEntities.MongoUser;
import ru.CrazyTalegram.MessageServer.Service.UserService;

import java.util.List;

@Controller
@RequiredArgsConstructor
public class UserController {

    private final UserService _userService;

    @MessageMapping("/user.addUser")
    @SendTo("/user/topic")
    public MongoUser addUser(@Payload MongoUser user) {
        _userService.saveUser(user);
        return user;
    }

    @MessageMapping("/user.disconnectUser")
    @SendTo("/user/topic")
    public MongoUser disconnect(@Payload MongoUser user) {
        _userService.disconnect(user);
        return user;
    }

    @GetMapping("/users")
    public ResponseEntity<List<MongoUser>> findConnectedUsers() {
        return ResponseEntity.ok(_userService.findConnectUsers());
    }

}
