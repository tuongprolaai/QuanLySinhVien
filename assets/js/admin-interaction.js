document.addEventListener("DOMContentLoaded", function () {
    // --- Student Modal Logic ---
    const studentModalOverlay = document.getElementById(
        "student-modal-overlay"
    );
    if (studentModalOverlay) {
        const studentForm = document.getElementById("student-form");
        const modalTitle = document.getElementById("modal-title");

        const openStudentModal = (isEdit = false, data = {}) => {
            modalTitle.textContent = isEdit
                ? "Chỉnh Sửa Thông Tin Sinh Viên"
                : "Thêm Mới Sinh Viên";
            if (isEdit) {
                document.getElementById("student-name").value = data.name;
                document.getElementById("student-class").value = data.class;
                document.getElementById("student-email").value = data.email;
            } else {
                studentForm.reset();
            }
            studentModalOverlay.classList.add("active");
        };

        const closeStudentModal = () =>
            studentModalOverlay.classList.remove("active");

        document
            .querySelector(".toolbar .btn-primary")
            .addEventListener("click", () => openStudentModal(false));
        document.querySelectorAll("table .btn-warning").forEach((button) => {
            button.addEventListener("click", (e) => {
                const row = e.target.closest("tr");
                const data = {
                    name: row.cells[1].textContent,
                    class: row.cells[2].textContent,
                    email: row.cells[3].textContent,
                };
                openStudentModal(true, data);
            });
        });

        studentModalOverlay
            .querySelectorAll(".close-button, #modal-close-btn")
            .forEach((btn) => btn.addEventListener("click", closeStudentModal));
        studentModalOverlay.addEventListener("click", (e) => {
            if (e.target === studentModalOverlay) closeStudentModal();
        });
        studentForm.addEventListener("submit", (e) => {
            e.preventDefault();
            alert("Lưu thông tin thành công! (demo)");
            closeStudentModal();
        });
    }

    // --- Teacher Modal Logic ---
    const teacherModalOverlay = document.getElementById(
        "teacher-modal-overlay"
    );
    if (teacherModalOverlay) {
        const teacherForm = document.getElementById("teacher-form");
        const modalTitle = document.getElementById("teacher-modal-title");

        const openTeacherModal = (isEdit = false, data = {}) => {
            modalTitle.textContent = isEdit
                ? "Chỉnh Sửa Thông Tin Giảng Viên"
                : "Thêm Mới Giảng Viên";
            if (isEdit) {
                document.getElementById("teacher-name").value = data.name;
                document.getElementById("teacher-email").value = data.email;
                document.getElementById("teacher-subjects").value =
                    data.subjects;
            } else {
                teacherForm.reset();
            }
            teacherModalOverlay.classList.add("active");
        };

        const closeTeacherModal = () =>
            teacherModalOverlay.classList.remove("active");

        document
            .querySelector(".toolbar .btn-primary")
            .addEventListener("click", () => openTeacherModal(false));
        document.querySelectorAll("table .btn-warning").forEach((button) => {
            button.addEventListener("click", (e) => {
                const row = e.target.closest("tr");
                const data = {
                    name: row.cells[1].textContent,
                    email: row.cells[2].textContent,
                    subjects: row.cells[3].textContent,
                };
                openTeacherModal(true, data);
            });
        });

        teacherModalOverlay
            .querySelectorAll(".close-button, #teacher-modal-close-btn")
            .forEach((btn) => btn.addEventListener("click", closeTeacherModal));
        teacherModalOverlay.addEventListener("click", (e) => {
            if (e.target === teacherModalOverlay) closeTeacherModal();
        });
        teacherForm.addEventListener("submit", (e) => {
            e.preventDefault();
            alert("Lưu thông tin thành công! (demo)");
            closeTeacherModal();
        });
    }

    // --- Subject Modal Logic ---
    const subjectModalOverlay = document.getElementById(
        "subject-modal-overlay"
    );
    if (subjectModalOverlay) {
        const subjectForm = document.getElementById("subject-form");
        const modalTitle = document.getElementById("subject-modal-title");

        const openSubjectModal = (isEdit = false, data = {}) => {
            modalTitle.textContent = isEdit
                ? "Chỉnh Sửa Môn Học"
                : "Thêm Mới Môn Học";
            if (isEdit) {
                document.getElementById("subject-name").value = data.name;
                document.getElementById("subject-credits").value = data.credits;
                document.getElementById("subject-teacher").value = data.teacher;
            } else {
                subjectForm.reset();
            }
            subjectModalOverlay.classList.add("active");
        };

        const closeSubjectModal = () =>
            subjectModalOverlay.classList.remove("active");

        document
            .querySelector(".toolbar .btn-primary")
            .addEventListener("click", () => openSubjectModal(false));
        document.querySelectorAll("table .btn-warning").forEach((button) => {
            button.addEventListener("click", (e) => {
                const row = e.target.closest("tr");
                const data = {
                    name: row.cells[0].textContent,
                    credits: row.cells[1].textContent,
                    teacher: row.cells[2].textContent,
                };
                openSubjectModal(true, data);
            });
        });

        subjectModalOverlay
            .querySelectorAll(".close-button, #subject-modal-close-btn")
            .forEach((btn) => btn.addEventListener("click", closeSubjectModal));
        subjectModalOverlay.addEventListener("click", (e) => {
            if (e.target === subjectModalOverlay) closeSubjectModal();
        });
        subjectForm.addEventListener("submit", (e) => {
            e.preventDefault();
            alert("Lưu thông tin thành công! (demo)");
            closeSubjectModal();
        });
    }

    // --- Generic Delete Confirmation Logic ---
    const deleteModalOverlay = document.getElementById(
        "delete-confirm-modal-overlay"
    );
    if (deleteModalOverlay) {
        let rowToDelete = null;

        document.querySelectorAll("table .btn-danger").forEach((button) => {
            button.addEventListener("click", (e) => {
                rowToDelete = e.target.closest("tr");
                deleteModalOverlay.classList.add("active");
            });
        });

        const closeDeleteModal = () => {
            deleteModalOverlay.classList.remove("active");
            rowToDelete = null;
        };

        document
            .getElementById("delete-confirm-btn")
            .addEventListener("click", () => {
                if (rowToDelete) {
                    rowToDelete.remove();
                    alert("Đã xóa thành công!");
                }
                closeDeleteModal();
            });

        deleteModalOverlay
            .querySelectorAll(".close-button, #delete-cancel-btn")
            .forEach((btn) => btn.addEventListener("click", closeDeleteModal));
        deleteModalOverlay.addEventListener("click", (e) => {
            if (e.target === deleteModalOverlay) closeDeleteModal();
        });
    }
    // --- Class Modal Logic ---
    const classModalOverlay = document.getElementById("class-modal-overlay");
    if (classModalOverlay) {
        const classForm = document.getElementById("class-form");
        const modalTitle = document.getElementById("class-modal-title");

        const openClassModal = (isEdit = false, data = {}) => {
            modalTitle.textContent = isEdit
                ? "Chỉnh Sửa Thông Tin Lớp Học"
                : "Thêm Mới Lớp Học";
            if (isEdit) {
                document.getElementById("class-name").value = data.name;
                document.getElementById("class-department").value =
                    data.department;
            } else {
                classForm.reset();
            }
            classModalOverlay.classList.add("active");
        };

        const closeClassModal = () =>
            classModalOverlay.classList.remove("active");

        document
            .querySelector(".toolbar .btn-primary")
            .addEventListener("click", () => openClassModal(false));
        document.querySelectorAll("table .btn-warning").forEach((button) => {
            button.addEventListener("click", (e) => {
                const row = e.target.closest("tr");
                const data = {
                    name: row.cells[0].textContent,
                    department: row.cells[1].textContent,
                };
                openClassModal(true, data);
            });
        });

        classModalOverlay
            .querySelectorAll(".close-button, #class-modal-close-btn")
            .forEach((btn) => btn.addEventListener("click", closeClassModal));
        classModalOverlay.addEventListener("click", (e) => {
            if (e.target === classModalOverlay) closeClassModal();
        });
        classForm.addEventListener("submit", (e) => {
            e.preventDefault();
            alert("Lưu thông tin thành công! (demo)");
            closeClassModal();
        });
    }
});
