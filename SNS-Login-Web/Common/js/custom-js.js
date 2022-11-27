function callAjax(url) {

    $.ajax({
        url: url,
        type: "GET",
        success: function (result) {
            $("#divResultList").html(result);
        }
    })

}


function fnSignup(reqUrl) {

    var tempUrl = "https://www.workflow.com/workflow/oauth";
    var url = tempUrl + reqUrl;


    $.ajax({
        url: url,
        type: "GET",
        success: function (result) {
            var idx = result._idx;

            if (idx != 0) {
                alert("회원가입에 성공하였습니다.");
                window.location.href = "https://www.workflow.com/workflow/login/Index";
            }


        }
    })

}
function validate() {
    var re = /^[a-zA-Z0-9]{4,12}$/ // 아이디와 패스워드가 적합한지 검사할 정규식
    var re2 = /^[0-9a-zA-Z]([-_.]?[0-9a-zA-Z])*@[0-9a-zA-Z]([-_.]?[0-9a-zA-Z])*.[a-zA-Z]{2,3}$/i;
    // 이메일이 적합한지 검사할 정규식

    var nickName = document.getElementById("inputName");


    // ------------ 이메일 까지 -----------

    if (!check(re, nickName, "아이디는 4~12자의 영문 대소문자와 숫자로만 입력")) {

        return false;
    }
    else {

    }
    alert("회원가입이 완료되었습니다.");
}



function check(re, what, message) {
    if (re.test(what.value)) {
        return true;
    }
    alert(message);
    what.value = "";
    what.focus();
    //return false;
}
