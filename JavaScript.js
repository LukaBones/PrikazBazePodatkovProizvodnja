function handleClickRadioButtonTime(radio) {
    /*var radioButtonTime = document.getElementById('radioButtonTime');
    radioButtonTime.value = this.value;
    __doPostBack(); */
    var radiosTime = document.getElementsByName('radioTime');
    var radioButtonTimeValue = document.getElementById('radioButtonTimeValue');
    var radioStatus = document.getElementsByName('radioStatus');
    var radioButtonStatusValue = document.getElementById('radioButtonStatusValue');

    for (var i = 0, length = radiosTime.length; i < length; i++) {
        if (radiosTime[i].checked) {
            // do whatever you want with the checked radio
            //alert(radios[i].value);
            radioButtonTimeValue.value = radiosTime[i].value;
            // only one radio can be logically checked, don't check the rest
            break;
        }
    }

    //<label for="walk" class="radio-tile-label">VSI</label>
    for (var i = 0, length = radioStatus.length; i < length; i++) {
        if (radioStatus[i].checked) {
            // do whatever you want with the checked radio
            //alert(radios[i].value);
            radioButtonStatusValue.value = radioStatus[i].value;
            // only one radio can be logically checked, don't check the rest
            break;
        }
    }
    __doPostBack(); 
}

function radioButtonHistoryStatusValueChanged(radio) {
    alert("asdlfk");
    var radioStatus = document.getElementsByName('radioHistoryStatus');
    var radioButtonStatusValue = document.getElementById('radioButtonHistoryStatusValue');
    for (var i = 0, length = radioStatus.length; i < length; i++) {
        if (radioStatus[i].checked) {
            radioButtonStatusValue.value = radioStatus[i].value;
            break;
        }
    }
    __doPostBack(); 
}
