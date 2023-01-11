export default function authHeader() {
  if (localStorage.getItem("user") != null) {
    const user = JSON.parse(localStorage.getItem("user")!);

    if (user.token) {
      return { Authorization: "Bearer " + user.token };
    } else {
      return {};
    }
  } else {
    return {};
  }
}
