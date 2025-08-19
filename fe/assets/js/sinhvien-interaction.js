document.addEventListener("DOMContentLoaded", function () {
    const profileForm = document.getElementById("profile-form");

    if (profileForm) {
        const updateButton = document.getElementById("update-profile-btn");

        profileForm.addEventListener("submit", function (e) {
            e.preventDefault();

            if (updateButton) {
                const originalHTML = updateButton.innerHTML;
                updateButton.innerHTML = `<i class="fas fa-spinner fa-spin"></i><span>Đang cập nhật...</span>`;
                updateButton.disabled = true;

                setTimeout(() => {
                    alert("Cập nhật thông tin thành công!");
                    updateButton.innerHTML = originalHTML;
                    updateButton.disabled = false;
                }, 1500);
            }
        });
    }
});
