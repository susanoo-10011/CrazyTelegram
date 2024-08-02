package ru.CrazyTalegram.MessageServer.Controllers;

import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.messaging.handler.annotation.MessageMapping;
import org.springframework.messaging.handler.annotation.Payload;
import org.springframework.messaging.simp.SimpMessagingTemplate;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import ru.CrazyTalegram.MessageServer.Model.ChatNotification;
import ru.CrazyTalegram.MessageServer.Model.MongoDBEntities.ChatMessage;
import ru.CrazyTalegram.MessageServer.Service.ChatMessageService;

import java.util.List;

@Controller
@RequiredArgsConstructor
public class ChatController {

    private final SimpMessagingTemplate _messagingTemplate;
    private final ChatMessageService _chatMessageService;

    @GetMapping("/messages/{senderId}/{recipientId}")
    public ResponseEntity<List<ChatMessage>> findChatMessages(
            @PathVariable("senderId") String senderId,
            @PathVariable("recipientId") String recipientId) {

        return ResponseEntity.ok(_chatMessageService.findChatMessages(senderId, recipientId));
    }

    @MessageMapping("/chat")
    public void processMessage(@Payload ChatMessage chatMessage) {
        ChatMessage savedMessage = _chatMessageService.save(chatMessage);
        _messagingTemplate.convertAndSendToUser(
                chatMessage.getRecipientId(),
                "/queue/messages",
                ChatNotification.builder()
                        .id(savedMessage.getId())
                        .senderId(chatMessage.getSenderId())
                        .recipientId(savedMessage.getRecipientId())
                        .content(chatMessage.getContent())
                        .build()
        );
    }
}
