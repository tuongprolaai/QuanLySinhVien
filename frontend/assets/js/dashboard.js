document.addEventListener("DOMContentLoaded", () => {
    const sidebarContainer = document.getElementById("sidebar-container");

    // Hàm để tải và chèn sidebar vào trang
    const loadSidebar = (sidebarUrl) => {
        fetch(sidebarUrl)
            .then((response) => {
                if (!response.ok) {
                    throw new Error("Network response was not ok");
                }
                return response.text();
            })
            .then((data) => {
                if (sidebarContainer) {
                    sidebarContainer.innerHTML = data;
                    setActiveMenuItem(); // Kích hoạt menu sau khi sidebar đã được tải
                }
            })
            .catch((error) => {
                console.error("Error loading sidebar:", error);
                if (sidebarContainer) {
                    sidebarContainer.innerHTML = "<p>Lỗi tải menu.</p>";
                }
            });
    };

    // Hàm để tự động highlight menu item tương ứng với trang hiện tại
    const setActiveMenuItem = () => {
        // Lấy tên file của trang hiện tại (ví dụ: "sinh-vien.html")
        const currentPage = window.location.pathname.split("/").pop();
        const navLinks = document.querySelectorAll(".sidebar-nav a");

        navLinks.forEach((link) => {
            const linkPage = link.getAttribute("href").split("/").pop();
            const parentLi = link.parentElement;

            // Xóa class 'active' cũ trước khi thêm mới
            parentLi.classList.remove("active");

            if (linkPage === currentPage) {
                parentLi.classList.add("active");
            }
        });
    };

    // Tự động gọi hàm loadSidebar dựa trên URL
    // Giả sử URL có dạng /admin/..., /giangvien/..., /sinhvien/...
    const path = window.location.pathname;
    if (path.includes("/admin/")) {
        loadSidebar("../templates/admin-sidebar.html");
    } else if (path.includes("/giangvien/")) {
        loadSidebar("../templates/giangvien-sidebar.html");
    } else if (path.includes("/sinhvien/")) {
        loadSidebar("../templates/sinhvien-sidebar.html");
    }
});
