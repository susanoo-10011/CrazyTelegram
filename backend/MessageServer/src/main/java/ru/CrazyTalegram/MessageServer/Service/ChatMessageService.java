package ru.CrazyTalegram.MessageServer.Service;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import ru.CrazyTalegram.MessageServer.Model.MongoDBEntities.ChatMessage;
import ru.CrazyTalegram.MessageServer.Repository.ChatMessageRepository;

import java.util.ArrayList;
import java.util.List;

@Service
@RequiredArgsConstructor
public class ChatMessageService {

    private final ChatMessageRepository _chatMessageRepository;
    private final ChatRoomService _chatRoomService;

    public ChatMessage save(ChatMessage chatMessage) {
        var chatId = _chatRoomService.getChatRoomId(
                chatMessage.getSenderId(),
                chatMessage.getRecipientId(),
                true
        ).orElseThrow(null); //здесь можно создать свое исключение

        chatMessage.setSenderId(chatId);
        _chatMessageRepository.save(chatMessage);
        return chatMessage;
    }

    public List<ChatMessage> findChatMessages(String senderId, String recipientId) {

        var chatId = _chatRoomService.getChatRoomId(
                senderId,
                recipientId,
                false);

        return chatId.map(_chatMessageRepository::findByChatId).orElse(new ArrayList<>());
    }
}
