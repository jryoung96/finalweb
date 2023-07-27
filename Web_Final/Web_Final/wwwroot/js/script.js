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

//삭제





