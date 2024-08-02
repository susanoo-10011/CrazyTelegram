package ru.CrazyTalegram.MessageServer.Model.PostgresDatabaseEntities;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import lombok.Data;

import java.time.LocalDateTime;

@Data
@Entity
@Table(name = "messages", schema = "auth_schema")
public class Messages {

    @Id
    @JsonIgnore
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(name = "text")
    private String text;

    @Column(name = "created_at")
    private LocalDateTime createdDate;

    @ManyToOne
    @JoinColumn(name = "sender_Id", nullable = false)
    @JsonIgnore
    private User senderId;

    @ManyToOne(optional = true)
    @JoinColumn(name = "reply_id", insertable = false, updatable = false)
    private Messages replyId;

}
