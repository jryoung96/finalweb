//경고메시지: valid-feedback / invalid-feedback : div
//텍스트박스: is-valid / is-invalid 
var id = $("#userid");
var pw = $("#pw");
var pw2 = $("#pw2");
var user_name = $("#username");
var msg_id = $("#msg-id");
var msg_pw = $("#msg-pw");
var msg_pw2 = $("#msg-pw2");
var msg_name = $("#msg-name");
//정규식
var regex_id = /^[a-zA-Z0-9]{4,20}$/; //영문 숫자 4~20자리
var regex_pw = /^(?=.*[a-zA-Z])(?=.*\d)[A-Za-z\d]{8,16}$/; //영문 숫자 포함 8~16자리
var regex_name = /^[가-힣]{2,5}(?:\s[가-힣]{2,5})?$/;
//유효성검사


$(user_name).on("input", function () {
    if (!regex_name.test(user_name.val())) {
        user_name.removeClass("is-valid");
        user_name.addClass("is-invalid");
        msg_name.removeClass("valid-feedback");
        msg_name.addClass("invalid-feedback");
        msg_name.text("올바른 이름이 아닙니다.");
    } else {
        user_name.removeClass("is-invalid");
        user_name.addClass("is-valid");
        msg_name.removeClass("invalid-feedback");
        msg_name.addClass("valid-feedback");
        msg_name.text("OK!");
    }
});

$(id).on("input", function () {
    if (!regex_id.test(id.val())) {
        id.removeClass("is-valid");
        id.addClass("is-invalid");
        msg_id.removeClass("is-valid");
        msg_id.addClass("invalid-feedback");
        msg_id.text("아이디는 영문 숫자 4~20자 입니다.");
    } else {
        id.removeClass("is-invalid");
        id.addClass("is-valid");
        msg_id.removeClass("invalid-feedback");
        msg_id.addClass("valid-feedback");
        msg_id.text("OK!");
    }
});

$(pw).on("input", function () {
    if (!regex_pw.test(pw.val())) {
        pw.removeClass("is-valid");
        pw.addClass("is-invalid");
        msg_pw.removeClass("valid-feedback");
        msg_pw.addClass("invalid-feedback");
        msg_pw.text("비밀번호는 영문 숫자 포함 8~16자 입니다.");
    } else {
        pw.removeClass("is-invalid");
        pw.addClass("is-valid");
        msg_pw.removeClass("invalid-feedback");
        msg_pw.addClass("valid-feedback");
        msg_pw.text("OK!");
    }
});

$(pw2).on("input", function () {
    if ((pw2.val() == null || $.trim(pw2.val()) == "") || (pw.val() == null || $.trim(pw.val()) == "")) {
        msg_pw2.removeClass("valid-feedback");
        pw2.removeClass("is-valid");
        msg_pw2.removeClass("invalid-feedback");
        pw2.removeClass("is-invalid");
        msg_pw2.text("");

        msg_pw.removeClass("valid-feedback");
        pw.removeClass("is-valid");
        msg_pw.removeClass("invalid-feedback");
        pw.removeClass("is-invalid");
        msg_pw.text("");
    }
   else if (pw.val() !== pw2.val() ) {
        pw2.removeClass("is-valid");
        pw2.addClass("is-invalid");
        msg_pw2.removeClass("valid-feedback");
        msg_pw2.addClass("invalid-feedback");
        msg_pw2.text("비밀번호가 일치하지 않습니다!");

    } else {
        pw2.removeClass("is-invalid");
        pw2.addClass("is-valid");
        msg_pw2.removeClass("invalid-feedback");
        msg_pw2.addClass("valid-feedback");
        msg_pw2.text("OK!");
    }
});
