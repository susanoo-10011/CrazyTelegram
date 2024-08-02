import styles from "./MainPage.module.scss";
import Layout from "../../../app/layout";
import { Message } from "../../../features/message/index";

export const MainPage = () => {
  return (
    <Layout>
      <div className={styles.main}>MainPage</div>
      <Message
        message={{
          id: "0",
          userid: "0",
          text: "Здарова",
          time: new Date(),
          replyId: "0",
        }}
        type="top"
      ></Message>
      <Message
        message={{
          id: "0",
          userid: "0",
          text: "Провер очка сообщений",
          time: new Date(),
          replyId: "0",
        }}
        type="middle"
      ></Message>
      <Message
        message={{
          id: "0",
          userid: "0",
          text: "Текст (от лат. textus — ткань; сплетение, сочетание) — зафиксированная на каком-либо материальном носителе человеческая мысль; в общем плане связная и полная последовательность символов.",
          time: new Date(),
          replyId: "0",
        }}
        type="bottom"
      ></Message>
      <Message
        message={{
          id: "0",
          userid: "0",
          text: "Привет, крутая проверка!!!👍",
          time: new Date(),
          replyId: "0",
        }}
        own
        type="top"
      ></Message>
      <Message
        message={{
          id: "0",
          userid: "0",
          text: "Как по юности с дому сбежал Так с тех пор не могу усидеть Я на месте одном и ни дня В приключение всё тянет залезть",
          time: new Date(),
          replyId: "0",
        }}
        own
        type="bottom"
      ></Message>
    </Layout>
  );
};
