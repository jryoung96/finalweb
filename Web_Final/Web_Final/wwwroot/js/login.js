var id = $("#username");
var pw = $("#pw");
$("#btn_login").on("click", function () {
    if (id == null || $.trim(id.val()) == "") {
        alert("아이디를 입력하세요!");
        id.focus();
        return false;
    }
    else if (pw == null || pw.val() == "") {
        alert("비밀번호를 입력하세요!");
        pw.focus();
        return false;
    }
    $("#login").submit();
})