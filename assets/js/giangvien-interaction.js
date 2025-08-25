document.addEventListener("DOMContentLoaded", function () {
    const classSelector = document.getElementById("class-selector");
    const studentListBody = document.getElementById("student-list-body");
    const pageTitle = document.getElementById("page-title");
    const saveButton = document.getElementById("save-grades-btn");

    const sampleData = {
        CNTT1: `
            <tr>
                <td>SV001</td><td>Nguyễn Văn A</td>
                <td><input type="number" class="grade-input" step="0.1" min="0" max="10" value="8.5"></td>
                <td><input type="number" class="grade-input" step="0.1" min="0" max="10" value="7.0"></td>
                <td><input type="number" class="grade-input" step="0.1" min="0" max="10" value="9.0"></td>
            </tr>
            <tr>
                <td>SV002</td><td>Trần Thị B</td>
                <td><input type="number" class="grade-input" step="0.1" min="0" max="10" value="7.5"></td>
                <td><input type="number" class="grade-input" step="0.1" min="0" max="10" value="8.0"></td>
                <td><input type="number" class="grade-input" step="0.1" min="0" max="10" value="8.5"></td>
            </tr>`,
        CNTT2: `
            <tr>
                <td>SV010</td><td>Phạm Hùng Dũng</td>
                <td><input type="number" class="grade-input" step="0.1" min="0" max="10"></td>
                <td><input type="number" class="grade-input" step="0.1" min="0" max="10"></td>
                <td><input type="number" class="grade-input" step="0.1" min="0" max="10"></td>
            </tr>
            <tr>
                <td>SV011</td><td>Vũ Thị Lan</td>
                <td><input type="number" class="grade-input" step="0.1" min="0" max="10"></td>
                <td><input type="number" class="grade-input" step="0.1" min="0" max="10"></td>
                <td><input type="number" class="grade-input" step="0.1" min="0" max="10"></td>
            </tr>`,
    };

    if (classSelector) {
        classSelector.addEventListener("change", function () {
            const selectedClass = this.value;
            if (pageTitle) {
                pageTitle.textContent = `Nhập điểm sinh viên lớp ${selectedClass}`;
            }
            if (studentListBody) {
                studentListBody.innerHTML =
                    sampleData[selectedClass] ||
                    '<tr><td colspan="5">Không có dữ liệu cho lớp này.</td></tr>';
            }
        });
    }

    if (saveButton) {
        saveButton.addEventListener("click", function () {
            const originalHTML = this.innerHTML;
            this.innerHTML = `<i class="fas fa-spinner fa-spin"></i><span>Đang lưu...</span>`;
            this.disabled = true;

            setTimeout(() => {
                this.innerHTML = `<i class="fas fa-check"></i><span>Đã lưu!</span>`;
                setTimeout(() => {
                    this.innerHTML = originalHTML;
                    this.disabled = false;
                }, 2000);
            }, 1500);
        });
    }
});
