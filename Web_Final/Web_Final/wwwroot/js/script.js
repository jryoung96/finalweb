//사원정보 수정 시, 존재여부 확인
$("#check_code").on("click", function () {
    var input = $("#code").val();
    var url = "/Factory/Check?p_code=" + encodeURIComponent(input);

    // Fetch 요청
    fetch(url)
        .then(function (response) {
            if (!response.ok) {
                alert("잠시 후 다시 시도하세요");
                throw new Error("서버 요청에 실패했습니다. 다시 시도해주세요.");
            }
            return response.json();
        })
        .then(function (result) {
            if (result == "available") {
                // 성공 시 동작
                alert("확인되었습니다.");
                $("#exist_id").val("true");
            } else {
                // 실패 시 동작
                alert("존재하지 않는 사원입니다.");
            }
        });
});

//
$("#edit").on("click", function () {
    alert("사원정보 수정이 완료되었습니다.");
})


$("#reset").on("click", function () {
    var input = $("#code").val();
    var url = "/Factory/ResetPw";
    var res = confirm("비밀번호가 0000으로 초기화 됩니다. 정말로 진행하시겠습니까?");
    var data = "Go";
    if (res) {
        //예
        fetch(url, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(data),
        })
            .then(response => response.json())
            .then(result => { // fetch >> controller로  json 전송완료
                if (result === "Success") {
                    alert("완료되었습니다.");
                } else if (result === "Fail") {
                    alert("잠시 후 다시하세요.");
                }
            })
            .catch(error => {
                alert("서버에 문제가 발생했습니다. 잠시후 다시 해 주세요.");
            });
    } else {
        //아니오
    }
});




