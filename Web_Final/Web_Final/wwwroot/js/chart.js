
    const ctx = $("#chart");
    let chart;
    let labels;
    let data;
    window.onload = function () { //페이지 로딩이 끝날 시점
        fetch("/Factory/CountJson")
            .then(response => response.json())
            .then((result) => {
                labels = result.map(o => o.name);
                data = result.map(o => o.count);
                createChart(labels, data);

                //0.1초마다 차트 업데이트
                setInterval(updateChart, 100)
            })
    };

const createChart = function (labels, data) {
    if (chart) {
        //수량 변경시 기존에 있던 차트를 지우고 새로 생성
        chart.destroy();
    }
        // Chart는 chart.js에서 자체 제공 각 변수는 (첫번째)
        chart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: labels,
                datasets: [{
                    label: '생산수량',
                    data: data,
                    borderWidth: 1
                },],
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true,
                    }
                }
            }
        });
    }
    const updateChart = function () {
        fetch("/Factory/CountJson")
            .then(response => response.json())
            .then((countObj) => {
                labels = countObj.map(o => o.name);
                data = countObj.map(o => o.count);
                chart.data.labels = labels;
                chart.data.datasets[0].data = data;
                chart.update();
            }
            )
    }
