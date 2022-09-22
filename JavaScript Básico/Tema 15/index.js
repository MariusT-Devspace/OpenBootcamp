
const firstName = "Juan";
const lastName = "Gonzales";

const fullName = {
    "firstName": firstName,
    "lastName": lastName
}
const now = new Date();
const minutes = 2;
const cookieExpiration = new Date(now.getTime() + (minutes * 60 * 1000));

sessionStorage.setItem("Name", JSON.stringify(fullName));
localStorage.setItem("Name", JSON.stringify(fullName));
document.cookie = "fullName="+JSON.stringify(fullName)+";expires=" + 
                    cookieExpiration.toUTCString();