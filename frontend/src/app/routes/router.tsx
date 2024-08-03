import { MainPage } from "@pages/main";
import { NotFoundPage } from "@pages/not-found";

export const routes = [
  {
    path: "/",
    element: <MainPage />,
  },
  {
    path: "*",
    element: <NotFoundPage />,
  },
];
