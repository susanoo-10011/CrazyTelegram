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
        author={{ id: "0", name: "Братан", imgUrl: "" }}
        onReply={(id: string) => console.log(id)}
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
        author={{ id: "0", name: "Братан", imgUrl: "" }}
        onReply={(id: string) => console.log(id)}
        type="middle"
      ></Message>
      <Message
        message={{
          id: "0",
          userid: "0",
          text: "В истерике кружилась мама Валя На заднем фоне замер папа Толя В радиусе метра воцарился жесточайший хаос Когда всем понятно стало: сын остался без диплома",
          time: new Date(),
          replyId: "0",
        }}
        author={{ id: "0", name: "Братан", imgUrl: "" }}
        onReply={(id: string) => console.log(id)}
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
        author={{ id: "current user", name: "username", imgUrl: "" }}
        onReply={(id: string) => console.log(id)}
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
        author={{ id: "current user", name: "username", imgUrl: "" }}
        onReply={(id: string) => console.log(id)}
        type="bottom"
      ></Message>
      <Message
        message={{
          id: "0",
          userid: "0",
          text: "согласен",
          time: new Date(),
          replyId: "0",
        }}
        author={{ id: "0", name: "Братан", imgUrl: "" }}
        onReply={(id: string) => console.log(id)}
        type="single"
      ></Message>
    </Layout>
  );
};
