function Welcome(person: string) {
    return "<h2>سلامممممم</h2>";
}

function ClickMeButton() {
    let user: string = "محمد سیارطهرانی";
    document.getElementById("divMsg").innerHTML = Welcome(user);
}