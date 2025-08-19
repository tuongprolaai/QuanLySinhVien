document.addEventListener("DOMContentLoaded", () => {
    const loginForm = document.getElementById("loginForm");

    if (loginForm) {
        loginForm.addEventListener("submit", function (event) {
            event.preventDefault(); // Ngăn form gửi đi theo cách truyền thống
            const username = document.getElementById("username").value;

            // Dựa vào kịch bản, chuyển hướng đến trang tương ứng
            switch (username) {
                case "admin":
                    window.location.href = "admin/index.html";
                    break;
                case "teacher01":
                    window.location.href = "giangvien/index.html";
                    break;
                case "sv001":
                    window.location.href = "sinhvien/index.html";
                    break;
                default:
                    alert("Tên đăng nhập không hợp lệ! Vui lòng thử lại.");
            }
        });
    }
});
