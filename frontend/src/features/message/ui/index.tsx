import styles from "./Message.module.scss";

type MessageType = {
  id: string;
  userid: string;
  text: string;
  time: Date;
  replyId: string;
};

type MessageParamsType = {
  message: MessageType;
  author: UserType;
  onReply: (messageId: string) => void;
  own?: boolean;
  type?: "top" | "middle" | "bottom" | "single";
};

type UserType = {
  id: string;
  name: string;
  imgUrl: string;
};

export function Message({
  message,
  author,
  onReply,
  type = "single",
}: MessageParamsType) {
  const own = author.id === "current user";
  return (
    <>
      {author && (
        <div
          className={`${styles.message} ${own ? styles.right : styles.left}
           ${styles[type]}`}
        >
          {!own && (type === "bottom" || type === "single") && (
            <img
              className={styles.pfp}
              src="https://img.freepik.com/free-vector/dark-black-background-design-with-stripes_1017-38064.jpg"
              alt=""
            />
          )}

          <div className={`${styles.content}`}>
            {!own && (type === "top" || type === "single") && (
              <div className={styles.first_row}>
                <div className={styles.name}>{author.name}</div>
                <button
                  className={styles.reply}
                  onClick={() => onReply(message.id)}
                >
                  Reply
                </button>
              </div>
            )}
            <div className={styles.text}>{message.text}</div>
            <div className={styles.time}>{formatTime(message.time)}</div>
            {(type === "bottom" || type === "single") && (
              <div className={styles.tail}></div>
            )}
          </div>
        </div>
      )}
    </>
  );
}

function formatTime(time: Date): string {
  let hours = time.getHours();
  let minutes: number | string = time.getMinutes();

  const ampm = hours >= 12 ? "PM" : "AM";

  hours = hours % 12;
  hours = hours ? hours : 12;

  minutes = minutes < 10 ? "0" + minutes : minutes;
  const timeString = `${hours}:${minutes} ${ampm}`;

  return timeString;
}
