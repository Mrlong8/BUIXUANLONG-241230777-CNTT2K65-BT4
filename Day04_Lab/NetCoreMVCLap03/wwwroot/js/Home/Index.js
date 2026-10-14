// JS HIỆU ỨNG CHẠY TĂNG SỐ LIỆU (ANIMATED COUNTER)
document.addEventListener("DOMContentLoaded", () => {
    const counters = document.querySelectorAll('.counter');
    const speed = 150;

    counters.forEach(counter => {
        const updateCount = () => {
            const target = +counter.getAttribute('data-target');
            const count = +counter.innerText.replace(/,/g, '');
            const inc = target / speed;

            if (count < target) {
                counter.innerText = Math.ceil(count + inc);
                setTimeout(updateCount, 20);
            } else {
                counter.innerText = target.toLocaleString();
            }
        };
        updateCount();
    });
});

//Đoạn code này dùng thư viện jQuery để gửi yêu cầu lấy danh sách sách từ Server và nhúng vào trang.
$(document).ready(function () {
    $('#loadAjax').click(function () {
        $('#data-form-ajax').html('<p class="text-info">Đang tải dữ liệu...</p>');

        // Gọi Ajax
        $('#data-form-ajax').load("/Book/PopularBook", function (response, status, xhr) {
            if (status == "error") {
                console.log("Lỗi Ajax: " + xhr.status + " " + xhr.statusText);
                $('#data-form-ajax').html('<p class="text-danger">Không thể tải dữ liệu! Vui lòng kiểm tra lại tên file PartialView.</p>');
            }
        });
    });
});