var common = {
    showLoading: function () {
        $("#overlay").fadeIn(300);
    },

    hideLoading: function () {
        $("#overlay").fadeOut(300);
    },

    showHideModal: function (id, type, isNestedDialog = false, title = null) {
        if (!isNestedDialog) {
            // Hiden form
            $(id + " .frmData").css("display", "none");
            $(id + " .frmDetail").css("display", "none");
            $(id + " .frmSettingRole").css("display", "none");
            $(id + " .frmViewImport").css("display", "none");
            $(id + " .frmDelete").css("display", "none");
            $(id + " .frmNestedModal").css("display", "none");
            $(id + " .frmImportExcel").css("display", "none");
            $(id + " .common-form").css("display", "none");
        } else {
            $(id + " .frmNestedModal .frmData").css("display", "none");
            $(id + " .frmNestedModal .frmViewImport").css("display", "none");
            $(id + " .frmNestedModal .frmDelete").css("display", "none");
            $(id + " .frmNestedModal .common-form").css("display", "none");
        }
        debugger
        var textOk = "Chỉnh sửa";
        ///Xóa các class màu nút đồng ý form chung. Bổ sung khi thêm nút
        var removeClassOK = "btn-smc-add btn-smc-edit btn-smc-delete";
        ///Class màu nút và chức năng nút mới
        var addClassOK = "btn-smc-edit";
        var formName = "";
        var formTitle = "";
        var isNetDialog = false;
        switch (type) {
            case 1:
                formName = "frmData";
                formTitle = constants.modal.modalHeader.lableInsert;
                textOk = "Tạo mới";
                addClassOK = "btn-smc-add";
                break;
            case 2:
                formName = "frmData";
                formTitle = constants.modal.modalHeader.lableUpdate;
                break;
            case 3:
                formName = "frmDetail";
                formTitle = constants.modal.modalHeader.lableDetail;
                break;
            case 4:
                formName = "frmDelete";
                formTitle = constants.modal.modalHeader.lableDelete;
                textOk = "Đồng ý";
                addClassOK = "btn-danger btn-smc-delete";
                break;
            case 5:
                formName = "frmSettingRole";
                formTitle = constants.modal.modalHeader.lableSettingRole;
                break;
            case 6:
                formName = "frmImportExcel";
                formTitle = constants.modal.modalHeader.lableImportFile;
                $("#btnOK").text("Import");
                textOk = "Import";
                addClassOK = "btn-smc-import";
                break;
            case 7:
                formName = "frmNestedModal";
                formTitle = constants.modal.modalHeader.lableFileInfo;
                isNetDialog = true;
                break;
            case 100:
                formName = "frmNestedModal";
                formTitle = constants.modal.modalHeader.lableInsert;
                isNetDialog = true;
                textOk = "Tạo mới";
                addClassOK = "btn-smc-add";
                break;
            case 101:
                formName = "frmNestedModal";
                formTitle = constants.modal.modalHeader.lableDelete;
                isNetDialog = true;
                $("#btnOKNestedDialog").text("Đồng ý");
                addClassOK = "btn-danger btn-smc-delete";
                break;
            case 102:
                formName = "frmNestedModal";
                formTitle = constants.modal.modalHeader.lableUpdate;
                isNetDialog = true;
                break;
            case 103:
                formName = "frmNestedModal";
                formTitle = constants.modal.modalHeader.lableSettingAccessAPI;
                isNetDialog = true;
                break;
        }
        if (title) {
            formTitle = title;
        }
        $("#btnOK").removeClass(removeClassOK);
        $("#btnOK").addClass(addClassOK);

        $("#btnOKNestedDialog").removeClass(removeClassOK);
        $("#btnOKNestedDialog").addClass(addClassOK);

        $("#btnOK").text(textOk);
        $("#btnOKNestedDialog").text(textOk);
        modal.showModal(id, formTitle, formName, true, isNetDialog);
    },

    emptyForm: function (idForm) {
        document.getElementById(idForm).reset();
        $.each($("#" + idForm).find("div"), function (index, item) {
            if ($(item).context.id.includes("-error")) {
                $(item).context.remove();
            }
        })
    },

    getStatus: function (status) {
        if (status === 1) {
            return '<span class="badge bg-green">Active</span>';
        } else {
            return '<span class="badge bg-red">InActive</span>';
        }
    },

    toActionLink: function (data, url, isBlank) {
        if (isBlank) {
            return '<a href="' + url + '" target = "_blank">' + data + '</a>';
        } else {
            return '<a href="' + url + '">' + data + '</a>';
        }
    },

    specialForm: function (isSpecial) {
        if (isSpecial) {
            $("#frmSpecial").css("display", "block");
        } else {
            $("#frmNormal").css("display", "block");
        }
    },

    formatDate: function (dateInput) {
        if (dateInput) {
            var date = new Date(dateInput);
            var month = (date.getMonth() + 1).toString();
            var day = date.getDate().toString();
            var a = month.length < 2 ? '0' + month : month;
            var b = day.length < 2 ? '0' + day : day;
            var response = b + '/' + a + '/' + date.getFullYear();
            return response;
        }
        return "";
    },

    formatDateTime: function (dateInput) {
        if (dateInput) {
            var date = new Date(dateInput);
            var month = (date.getMonth() + 1).toString();
            var day = date.getDate().toString();
            var a = month.length < 2 ? '0' + month : month;
            var b = day.length < 2 ? '0' + day : day;
            var hours = date.getHours().toString();
            var minutes = date.getMinutes().toString();
            var seconds = date.getSeconds().toString();
            let am_pm = (hours >= 12) ? "PM" : "AM";
            var response = b + '/' + a + '/' + date.getFullYear() + " " + hours + ":" + minutes + ":" + seconds + " " + am_pm;
            return response;
        }
        return '';
    },

    formatDateTimePart: function (dateInput) {
        if (dateInput) {
            var date = new Date(dateInput);
            var month = (date.getMonth() + 1).toString();
            var day = date.getDate().toString();
            var a = month.length < 2 ? '0' + month : month;
            var b = day.length < 2 ? '0' + day : day;
            var hours = parseInt(date.getHours().toString()) < 10 ? ('0' + date.getHours().toString()) : date.getHours().toString();
            var minutes = parseInt(date.getMinutes().toString()) < 10 ? ('0' + date.getMinutes().toString()) : date.getMinutes().toString();
            var seconds = parseInt(date.getSeconds().toString()) < 10 ? ('0' + date.getSeconds().toString()) : date.getSeconds().toString();
            var response = b + '/' + a + '/' + date.getFullYear() + " " + hours + ":" + minutes + ":" + seconds;
            return response;
        } else {
            return '';
        }
    },

    formatTime: function (dateInput) {
        if (dateInput) {
            var date = new Date(dateInput);
            var hours = date.getHours().toString();
            var minutes = date.getMinutes().toString().length < 2 ? "0" + date.getMinutes().toString() : date.getMinutes().toString();
            var seconds = date.getSeconds().toString().length < 2 ? "0" + date.getSeconds().toString() : date.getSeconds().toString();
            let am_pm = (hours >= 12) ? "PM" : "AM";
            var response = hours + ":" + minutes + ":" + seconds + " " + am_pm;
            return response;
        } else {
            return '';
        }
    },

    //format full: dd/mm/yyyy h:m:s
    formatDateTimeCustom: function (dateInput, formatDate, isampm = false) {
        if (dateInput) {
            var date = new Date(dateInput);
            var month = (date.getMonth() + 1).toString();
            var day = date.getDate().toString();
            var a = month.length < 2 ? '0' + month : month;
            var b = day.length < 2 ? '0' + day : day;
            var hours = date.getHours();
            var hourstxt = date.getHours().toString();
            let am_pm = "";
            if (isampm) {
                am_pm = (hours >= 12) ? " PM" : " AM";
                hourstxt = (hours > 12) ? (hours - 12).toString() : hours.toString();
            }
            var minutes = date.getMinutes().toString().length < 2 ? "0" + date.getMinutes().toString() : date.getMinutes().toString();
            var seconds = date.getSeconds().toString().length < 2 ? "0" + date.getSeconds().toString() : date.getSeconds().toString();
            if (formatDate) {
                formatDate = formatDate.toLowerCase();
                formatDate = formatDate.replace("dd", b).replace("mm", a).replace("yyyy", date.getFullYear()).replace("h", hourstxt).replace("m", minutes).replace("s", seconds);
                formatDate += am_pm;
                return formatDate;
            }
            else {
                return b + '/' + a + '/' + date.getFullYear() + " " + hourstxt + ":" + minutes + ":" + seconds + am_pm;
            }
        } else {
            return '';
        }
    },

    getDayOfWeak: function (day) {
        switch (day) {
            case 1:
                return "Thứ hai";
            case 2:
                return "Thứ ba";
            case 3:
                return "Thứ tư";
            case 4:
                return "Thứ năm";
            case 5:
                return "Thứ sáu";
            case 6:
                return "Thứ bay";
            case 0:
                return "Chủ nhật";
            default:
                return "";
        }
    },

    reloadDateRangePicker: function () {
        $('.single_cal').daterangepicker({
            singleDatePicker: true,
            singleClasses: "picker_3",
            locale: {
                format: 'DD/MM/YYYY'
            }
        }, function (start, end, label) {
            console.log(start.toISOString(), end.toISOString(), label);
        });
    },

    modalSizeSetting: function (size, idNestedDialog = null) {
        if (idNestedDialog) {
            $("#" + idNestedDialog + " .modalDialogCustom").removeClass("modal-lg");
            $("#" + idNestedDialog + " .modalDialogCustom").removeClass("modal-xl");
            $("#" + idNestedDialog + " .modalDialogCustom").removeClass("modal-dialog-full");
            $("#" + idNestedDialog + " .modal-content").removeClass("modal-content-full");
            if (size == "lg") {
                $("#" + idNestedDialog + " .modalDialogCustom").addClass("modal-lg");
            }

            if (size == "xl") {
                $("#" + idNestedDialog + " .modalDialogCustom").addClass("modal-xl");
            }

            if (size == "full") {
                $("#" + idNestedDialog + " .modalDialogCustom").addClass("modal-dialog-full");
                $("#" + idNestedDialog + " .modal-content").addClass("modal-content-full");
            }
        } else {
            $(".modalDialogCustom").removeClass("modal-lg");
            $(".modalDialogCustom").removeClass("modal-xl");
            $(".modalDialogCustom").removeClass("modal-dialog-full");
            $(".modal-content").removeClass("modal-content-full");
            if (size == "lg") {
                $(".modalDialogCustom").addClass("modal-lg");
            }

            if (size == "xl") {
                $(".modalDialogCustom").addClass("modal-xl");
            }

            if (size == "full") {
                $(".modalDialogCustom").addClass("modal-dialog-full");
                $(".modal-content").addClass("modal-content-full");
            }
        }
    },

    //Bỏ dấu tiếng việt
    removeAccents: function (input) {
        if (input) {
            input = input.replace(/á|à|ả|ạ|ã|ă|ắ|ằ|ẳ|ẵ|ặ|â|ấ|ầ|ẩ|ẫ|ậ/gi, 'a');
            input = input.replace(/é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ/gi, 'e');
            input = input.replace(/i|í|ì|ỉ|ĩ|ị/gi, 'i');
            input = input.replace(/ó|ò|ỏ|õ|ọ|ô|ố|ồ|ổ|ỗ|ộ|ơ|ớ|ờ|ở|ỡ|ợ/gi, 'o');
            input = input.replace(/ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự/gi, 'u');
            input = input.replace(/ý|ỳ|ỷ|ỹ|ỵ/gi, 'y');
            input = input.replace(/đ/gi, 'd');
        }
        return input;
    },

    convertToAlias: function (input, isLowcase = true) {
        if (input == undefined || input == '')
            return '';
        //Đổi chữ hoa thành chữ thường
        var slug = input;
        if (isLowcase) {
            var slug = input.toLowerCase();
        }


        //Đổi ký tự có dấu thành không dấu
        slug = slug.replace(/á|à|ả|ạ|ã|ă|ắ|ằ|ẳ|ẵ|ặ|â|ấ|ầ|ẩ|ẫ|ậ/gi, 'a');
        slug = slug.replace(/é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ/gi, 'e');
        slug = slug.replace(/i|í|ì|ỉ|ĩ|ị/gi, 'i');
        slug = slug.replace(/ó|ò|ỏ|õ|ọ|ô|ố|ồ|ổ|ỗ|ộ|ơ|ớ|ờ|ở|ỡ|ợ/gi, 'o');
        slug = slug.replace(/ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự/gi, 'u');
        slug = slug.replace(/ý|ỳ|ỷ|ỹ|ỵ/gi, 'y');
        slug = slug.replace(/đ/gi, 'd');
        //Xóa các ký tự đặt biệt
        slug = slug.replace(/\`|\~|\!|\@|\#|\||\$|\%|\^|\&|\*|\(|\)|\+|\=|\,|\.|\/|\?|\>|\<|\'|\"|\:|\;|_/gi, '');
        //Đổi khoảng trắng thành ký tự gạch ngang
        slug = slug.replace(/ /gi, "-");
        //Đổi nhiều ký tự gạch ngang liên tiếp thành 1 ký tự gạch ngang
        //Phòng trường hợp người nhập vào quá nhiều ký tự trắng
        slug = slug.replace(/\-\-\-\-\-/gi, '-');
        slug = slug.replace(/\-\-\-\-/gi, '-');
        slug = slug.replace(/\-\-\-/gi, '-');
        slug = slug.replace(/\-\-/gi, '-');
        //Xóa các ký tự gạch ngang ở đầu và cuối
        slug = '@' + slug + '@';
        slug = slug.replace(/\@\-|\-\@|\@/gi, '');

        return slug;
    },

    base64ToArrayBuffer: function (base64) {
        var binary_string = window.atob(base64);
        var len = binary_string.length;
        var bytes = new Uint8Array(len);
        for (var i = 0; i < len; i++) {
            bytes[i] = binary_string.charCodeAt(i);
        }
        return bytes.buffer;
    },

    formatDecimal(value, numAfterDot) {

        var newVl = Math.round(value * Math.pow(10, numAfterDot));
        return newVl / Math.pow(10, numAfterDot);
    },
    currencyFormat: function (value) {
        let v = value;
        v = v.replace(/[-\D]/g, '');
        v = v.replace(/\B(?=(\d{3})+(?!\d))/g, ".");
        return v
    },

    numberFormat: function (value) {
        let v = value;
        const neg = v.startsWith('-');

        v = v.replace(/[-\D]/g, '');
        if (neg) v = '-'.concat(v);
        return v
    },

    codeFormat: function (value) {
        // remove space
        value = value.replace(/\s/g, '');
        //value = value.replace(/[^a-zA-Z0-9]/g, "");
        return value;
    },

    urlFormat: function (value) {
        // remove space
        value = value.toLowerCase();
        //Đổi ký tự có dấu thành không dấu
        value = common.removeAccents(value);
        value = value.replace(/é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ/gi, 'e');
        value = value.replace(/i|í|ì|ỉ|ĩ|ị/gi, 'i');
        value = value.replace(/ó|ò|ỏ|õ|ọ|ô|ố|ồ|ổ|ỗ|ộ|ơ|ớ|ờ|ở|ỡ|ợ/gi, 'o');
        value = value.replace(/ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự/gi, 'u');
        value = value.replace(/ý|ỳ|ỷ|ỹ|ỵ/gi, 'y');
        value = value.replace(/đ/gi, 'd');

        value = value.replace(/[^\w\/]/g, '');
        //value = value.replace(/[^a-zA-Z0-9]/g, "");
        return value;
    },

    classFormat: function (value) {
        value = value.toLowerCase();
        value = common.removeAccents(value);
        value = value.replace(/[^\w|^\s|^\-]/g, '');
        return value;
    },
    emailFormat: function (value) {
        const isEmail = /^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/i;
        return isEmail.test(value);
    },

    vnPhoneNumber: function (value) {
        const isVNPhoneMobile = /^(0|\+84)(\s|\.)?((3[2-9])|(5[689])|(7[06-9])|(8[1-689])|(9[0-46-9]))(\d)(\s|\.)?(\d{3})(\s|\.)?(\d{3})$/;
        return isVNPhoneMobile.test(value);
    },

    ipV4Format: function (value) {
        const isIPv4 = /^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$/;
        return isIPv4.test(value);
    },

    ipV6Format: function (value) {
        const isIPv6 = "(([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))";
        return isIPv6.test(value);
    },

    nameFormat: function (value) {
        let v = value;
        v = v.replace(/[^A-Za-z0-9_-]{1,255}$/, '');
        return v
    },

    camelCase: function (str) {
        return str
            .replace(/\s(.)/g, function ($1) { return $1.toUpperCase(); })
            .replace(/\s/g, '')
            .replace(/^(.)/, function ($1) { return $1.toLowerCase(); });
    },

    handleAPIResponse: function (response, callback = null) {
        if (response && !response.success) {
            if (typeof (response) == 'string' && response?.includes('<p>ĐĂNG NHẬP HỆ THỐNG</p>')) {
                window.location.href = "/account/login/";
                return;
            }
            switch (response.code) {
                case 403:
                    window.location.href = "/error/unauthorized/";
                    break;
                case 401:
                    window.location.href = "/account/login/";
                    break;
                default:
                    notification.raise('Thông báo', response.message, 'error', 3000);
                    break;
            }
        }
        else {
            if (callback != null && typeof (callback) == 'function') {
                callback(response);
            }
            else {
                notification.raise('Thông báo', response.message, 'warning', 3000);
            }
        }
        common.hideLoading();
    },
    handleAPIError: function (xhr) {
        common.hideLoading();
        if (xhr.status == 401 || xhr.status == 403) {
            window.location.href = "/account/login/";
        }
        if (xhr.status = 200 && xhr.responseText.includes("!DOCTYPE")) {
            if (xhr.responseText.includes('<div class="error-code m-b-10 m-t-20">401<i class="fa fa-warning"></i></div>')) {
                window.location.href = "/error/unauthorized/";
            }
            else if (xhr.responseText.includes('<title>Login</title>')) {
                window.location.href = "/account/login/";
            }
        }
    },
    newGuid: function () {
        return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
            (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
        );
    },

    convertStringToDate: function (sdate) {
        if (sdate) {
            var arr = sdate.split("/");
            if (arr?.length == 3) {
                var dd = arr[0];
                var mm = arr[1];
                var yyyy = arr[2];
                return new Date(mm + "/" + dd + "/" + yyyy);
            }
        }
        return null;
    },

    setTabindex: function (isAutoFocus = false) {
        debugger
        setTimeout(() => {
            var tabindex = 1;
            $('a, input, select, button, textarea').each(function () {
                if (this.type != "hidden") {
                    var $input = $(this);
                    $input.attr("tabindex", tabindex);
                    tabindex++;
                    if (tabindex == 1 && isAutoFocus) {
                        $input.focus();
                    }
                }
            });
        }, 100);
    },

    buidButtonAction: function (lstButton) {
        var defaultButton = "";
        if (lstButton && lstButton.length) {
            var firstBtn = lstButton.find(x => x.IsFirst);
            if (!firstBtn) {
                lstButton[0].IsFirst = true;
                firstBtn = lstButton[0];
            }
            lstButton.splice(lstButton.findIndex(x => x.IsFirst), 1);
            defaultButton = "<button type=\"button\" class=\"btn btn-primary default-button " + firstBtn.StyleClass + " \" id=\"" + firstBtn.Id + "\" " + firstBtn.Attr + ">" + firstBtn.Label + "</button>";
            if (lstButton.length) {
                defaultButton = "<div class=\"btn-group style-button \">" + defaultButton;

                defaultButton += "<button type=\"button\" class=\"btn btn-primary dropdown-toggle\" data-toggle=\"dropdown\"><span class=\"caret\"></span><span class=\"sr-only\">Toggle Dropdown</span></button>";
                defaultButton += "<ul class=\"dropdown-menu\" role=\"menu\">";
                lstButton.forEach((btn) => {
                    defaultButton += "<li><a href=\"javascript:void(0)\" class=\"" + btn.StyleClass + "\" id=\"" + btn.Id + "\" " + btn.Attr + ">" + btn.Label + "</a></li>";
                });
                defaultButton += "</ul></div>";
            }
        }
        return defaultButton;
    },
}# TrainingMS

$(".currency").on({
    input: function () {
        // Handle change...
        $(this).val(common.currencyFormat(this.value));
    }
});

$('.numberOnly').on({
    //blur: function () {
    //    // Handle blur...
    //    common.numberFormat(this.value);
    //},
    //change: function () {
    //    // Handle change...
    //    common.numberFormat(this.value);
    //},
    input: function () {
        // Handle change...
        $(this).val(common.numberFormat(this.value));
    },
});

$('.code').on({
    input: function () {
        // Handle change...
        $(this).val(common.codeFormat(this.value));
    },
});

$('.name-format').on({
    input: function () {
        // Handle change...
        $(this).val(common.nameFormat(this.value));
    },
});

$('.ipV4').on({
    input: function () {
        debugger
        if (!common.ipV4Format(this.value)) {
            if (!$(this).parent().hasClass("has-error")) {
                $(this).parent().addClass("has-error")
            }

            $(".ipV4Error").text("IPV4 không đúng định dạng")
        } else {
            $(this).parent().removeClass("has-error")
            $(".ipV4Error").text("")
        }
    },
});

$('.vnPhoneNumber').on({
    input: function () {
        if (!common.vnPhoneNumber(this.value)) {
            if (!$(this).parent().hasClass("has-error")) {
                $(this).parent().addClass("has-error")
            }

            $(".vnPhoneNumberError").text("Số điện thoại không đúng định dạng")
        } else {
            $(this).parent().removeClass("has-error")
            $(".vnPhoneNumberError").text("")
        }
    },
});

$('.email').on({
    input: function () {
        if (!common.emailFormat(this.value)) {
            if (!$(this).parent().hasClass("has-error")) {
                $(this).parent().addClass("has-error")
            }

            $(".emailError").text("Email không đúng định dạng")
        } else {
            $(this).parent().removeClass("has-error")
            $(".emailError").text("")
        }
    },
});

TrainingMS
