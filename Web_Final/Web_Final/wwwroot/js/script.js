//정규식
var regex_id = /^[a-zA-Z0-9]{4,20}$/; //영문 숫자 4~20자리
var regex_pw = /^(?=.*[a-zA-Z])(?=.*\d)[A-Za-z\d]{8,16}$/; //영문 숫자 포함 
var regex_name = /^[가-힣]{2,5}(?:\s[가-힣]{2,5})?$/; //한글 2~5자

//로그인
$("#btn_login").on("click", function () {
    var id = $("#userid");
    var pw = $("#pw");
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
//계정생성버튼 클릭
$("#btn_create").on("click", function () {
    var name = $("#username");
    var dept = $("#dept");
    var position = $("#position");
    var id = $("#userid");
    var pw = $("#pw");
    var pw2 = $("#pw2");
    //중복검사 url
    var url = "/Factory/Check?p_code=" + encodeURIComponent(id.val());
    //양식 비었을때 커서 맞추고 false리턴
    if (name.val() == null || $.trim(name.val()) == "") {
        alert("이름을 입력해 주세요!");
        name.focus();
        return false;
    }
    
    else if (dept.val() == "none") {
        alert("부서를 선택해 주세요!");
        dept.focus();
        return false;
    }
    else if (position.val() == "none") {
        alert("직급을 선택해 주세요!");
        position.focus();
        return false;
    }
    else if (id.val() == null || $.trim(id.val()) == "") {
        alert("아이디를 입력하세요!");
        id.focus();
        return false;
    }
    else if (pw.val() == null || $.trim(pw.val()) == "") {
        alert("비밀번호를 입력하세요!");
        pw.focus();
        return false;
    }
    else if (pw.val() != pw2.val()) {
        alert("비밀번호가 일치하지 않습니다.");
        pw2.focus();
        return false;
    }
    //정규식 통과 실패
    else if (!regex_id.test(id.val())) {
        alert("아이디는 영문 숫자 4~20자 입니다.");
        id.focus();
        return false;
    }
    else if (!regex_pw.test(pw.val())) {
        alert("비밀번호는 영문 숫자 포함 8~16자 입니다.");
        pw.focus();
        return false;
    }
    else if (pw.val() != pw2.val()) {
        alert("비밀번호가 일치하지 않습니다.");
        pw.focus();
        return false;
    }

    //입력양식 통과
    else {
        //중복 아이디를 사용했을 경우
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
                    // 사용가능
                    $("#create").submit();
                    alert("계정이 생성되었습니다.");
                } else if (result == "exist") {
                    // 중복
                    alert("이미 사용중인 아이디 입니다.");
                    id.focus();
                    return false;
                }
                else {
                    alert("잘못된 접근 입니다!");
                    return false;

                }
            })
            .catch(error => {
                console.error("Error occurred during fetch:", error);
            });

    }
})


//수정 클릭시
$("#edit").on("click", function () {

    var id = $("#code");
    var dept = $("#dept");
    if (id.val() == null || $.trim(id.val()) == "") {
        alert("아이디를 입력해 주세요!");
        id.focus();
        return false;
    }
    else if (dept.val() == "none") {
        alert("부서를 선택해 주세요!!");
        dept.focus();
        return false;
    }
    var url = "/Factory/Check?p_code=" + encodeURIComponent(id.val());
    var res = confirm("사원정보를 수정 하시겠습니까?");
    if (res) {
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
                if (result == "exist") {
                    // 아이디 존재하면 동작
                    $("#update").submit();
                    alert("수정이 완료됐습니다.");
                } else if (result == "none") {
                    // 존재x
                    alert("존재하지 않는 사원입니다.");
                    return false;
                }
                else {
                    alert("잘못된 접근 입니다!");
                    return false;
                    
                }
            })
            .catch(error => {
                console.error("Error occurred during fetch:", error); 
            });
    }
});

//초기화 클릭 시
$("#btn_reset").on("click", function () {
    var id = $("#code");
    if (id.val == null || $.trim(id.val()) == "") {
        alert("아이디를 입력해주세요!");
        id.focus();
        return false;
    }
    var url = "/Factory/Check?p_code=" + encodeURIComponent(id.val());
    var res = confirm("확인을 누르면 비밀번호가 0000으로 초기화됩니다. 진행하시겠습니까?");
    if (res) {
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
                if (result == "exist") {
                    // 아이디 존재하면 동작
                    $("#reset").submit();
                    alert("비밀번호가 초기화 되었습니다.");
                } else if (result == "none") {
                    // 존재x
                    alert("존재하지 않는 사원입니다.");
                    return false;
                }
                else {
                    alert("잘못된 접근입니다.");
                    return false;
                }
            })
            .catch(error => {
                console.error("Error occurred during fetch:", error);
            });
    }
});

//삭제
$("#btn_delete").on("click", function () {
    var id = $("#code");
    if (id.val == null || $.trim(id.val()) == "") {
        alert("아이디를 입력해주세요!");
        id.focus();
        return false;
    }
    var url = "/Factory/Check?p_code=" + encodeURIComponent(id.val());
    var res = confirm("정말로 " + '"' + id.val() +'"'+"계정을 삭제하시겠습니까?");
    if (res) {
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
                if (result == "exist") {
                    // 아이디 존재하면 동작
                    $("#delete").submit();
                    alert("삭제 되었습니다.");
                } else if (result == "none") {
                    // 존재x
                    alert("존재하지 않는 사원입니다.");
                    return false;
                }
                else {
                    alert("잘못된 접근입니다.");
                    return false;
                }
            })
            .catch(error => {
                console.error("Error occurred during fetch:", error);
            });
    }
});



    






