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
var regex_name = /^[가-힣]{2,5}(?:\s[가-힣]{2,5})?$/; //한글 2~5자

//입력값 유효성검사

$(user_name).on("input", function () {
    if ((user_name.val() == null || $.trim(user_name.val()) == "")) {
        msg_name.removeClass("valid-feedback");
        user_name.removeClass("is-valid");
        msg_name.removeClass("invalid-feedback");
        user_name.removeClass("is-invalid");
        msg_name.text("");
    }
   else if (!regex_name.test(user_name.val())) {
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
    if ((id.val() == null || $.trim(id.val()) == "")) {
        msg_id.removeClass("valid-feedback");
        id.removeClass("is-valid");
        msg_id.removeClass("invalid-feedback");
        id.removeClass("is-invalid");
        msg_id.text("");
    }
    else if (!regex_id.test(id.val())) {
        id.removeClass("is-valid");
        id.addClass("is-invalid");
        msg_id.removeClass("is-valid");
        msg_id.addClass("invalid-feedback");
        msg_id.text("아이디는 영문 숫자 4~20자 입니다.");
    }
    else {
        //중복검사 url
        var url = "/Factory/Check?p_code=" + encodeURIComponent(id.val());
        fetch(url)
            .then(function (response) {
                if (!response.ok) {
                    alert("잠시 후 다시 시도하세요");
                    throw new Error("서버 요청에 실패했습니다. 다시 시도해주세요.");
                }
                return response.json(); // 아이디 존재여부 검사
            })
            .then(function (result) {
                console.log("Result from /Factory/Check:", result);
                if (result == "none") {
                    // 중복 아닐 때
                    id.removeClass("is-invalid");
                    id.addClass("is-valid");
                    msg_id.removeClass("invalid-feedback");
                    msg_id.addClass("valid-feedback");
                    msg_id.text("OK!");
                }
                else if (result == "exist") {
                    // 중복
                    id.removeClass("is-valid");
                    id.addClass("is-invalid");
                    msg_id.removeClass("valid-feedback");
                    msg_id.addClass("invalid-feedback");
                    msg_id.text("이미 사용중인 아이디 입니다.");
                }
            })
            .catch(error => {
                console.error("Error occurred during fetch:", error);
            });
        

    }
});

$(pw).on("input", function () {
    if ((pw.val() == null || $.trim(pw.val()) == "")) {
        msg_pw.removeClass("valid-feedback");
        pw.removeClass("is-valid");
        msg_pw.removeClass("invalid-feedback");
        pw.removeClass("is-invalid");
        msg_pw.text("");
    }
    else if (!regex_pw.test(pw.val())) {
        pw.removeClass("is-valid");
        pw.addClass("is-invalid");
        msg_pw.removeClass("valid-feedback");
        msg_pw.addClass("invalid-feedback");
        msg_pw.text("비밀번호는 영문 숫자 포함 8~16자 입니다.");
    }
    else if ($.trim(pw.val()) != "" && $.trim(pw2.val()) == "") {
        pw.removeClass("is-invalid");
        pw.addClass("is-valid");
        msg_pw.removeClass("invalid-feedback");
        msg_pw.addClass("valid-feedback");
        msg_pw.text("Good!");
    }
    else if ((pw2.val()!=null && $.trim(pw2.val()!="") && (pw.val() != pw2.val()))) {
        pw.removeClass("is-valid");
        pw.addClass("is-invalid");
        msg_pw.removeClass("valid-feedback");
        msg_pw.addClass("invalid-feedback");
        msg_pw.text("비밀번호가 일치하지 않습니다!");
    }

    else {
        pw.removeClass("is-invalid");
        pw.addClass("is-valid");
        msg_pw.removeClass("invalid-feedback");
        msg_pw.addClass("valid-feedback");
        msg_pw.text("Good!");

        if (pw.val() == pw2.val()) {
            pw2.removeClass("is-invalid");
            pw2.addClass("is-valid");
            msg_pw2.removeClass("invalid-feedback");
            msg_pw2.addClass("valid-feedback");
            msg_pw2.text("Good!");
        }
    }
});

$(pw2).on("input", function () {
    if ((pw2.val() == null || $.trim(pw2.val()) == "")) {
        msg_pw2.removeClass("valid-feedback");
        pw2.removeClass("is-valid");
        msg_pw2.removeClass("invalid-feedback");
        pw2.removeClass("is-invalid");
        msg_pw2.text("");
    }
   else if (pw.val() !== pw2.val() ) {
        pw2.removeClass("is-valid");
        pw2.addClass("is-invalid");
        msg_pw2.removeClass("valid-feedback");
        msg_pw2.addClass("invalid-feedback");
        msg_pw2.text("비밀번호가 일치하지 않습니다!");

    }
    else if (!regex_pw.test(pw2.val())) {
        pw.removeClass("is-valid");
        pw.addClass("is-invalid");
        msg_pw.removeClass("valid-feedback");
        msg_pw.addClass("invalid-feedback");
        msg_pw2.text("비밀번호는 영문 숫자 포함 8~16자 입니다.");
    }
    else {
        pw2.removeClass("is-invalid");
        pw2.addClass("is-valid");
        msg_pw2.removeClass("invalid-feedback");
        msg_pw2.addClass("valid-feedback");
        msg_pw2.text("Good!");
        if (pw.val() == pw2.val()) {
            pw.removeClass("is-invalid");
            pw.addClass("is-valid");
            msg_pw.removeClass("invalid-feedback");
            msg_pw.addClass("valid-feedback");
            msg_pw.text("Good!");
        }
    }
});


