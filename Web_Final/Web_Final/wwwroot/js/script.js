
//계정생성버튼 클릭
$("#btn_create").on("click", function () {
    var name = $("#name");
    var dept = $("#dept");
    var position = $("#position");
    var id = $("#userid");
    var pw = $("#pw");
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
    else {
    $("#create").submit();
    alert("계정이 생성되었습니다.");

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
                if (result == "available") {
                    // 아이디 존재하면 동작
                    $("#update").submit();
                    alert("수정이 완료됐습니다.");
                } else {
                    // 존재x
                    alert("존재하지 않는 사원입니다.");
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
                if (result == "available") {
                    // 아이디 존재하면 동작
                    $("#reset").submit();
                    alert("비밀번호가 초기화 되었습니다.");
                } else {
                    // 존재x
                    alert("존재하지 않는 사원입니다.");
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
                if (result == "available") {
                    // 아이디 존재하면 동작
                    $("#delete").submit();
                    alert("삭제 되었습니다.");
                } else {
                    // 존재x
                    alert("존재하지 않는 사원입니다.");
                    return false;
                }
            })
            .catch(error => {
                console.error("Error occurred during fetch:", error);
            });
    }
});



    






