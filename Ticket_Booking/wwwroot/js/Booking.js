var AisleTotalSeats, MiddleTotalSeats, WindowTotalSeats, TotalPayable;

$("#FromTOid").on("change", function () {

    $.ajax({
        url: "/Airline",
        type: "GET",
        cache: false,
        async: true,
        data: { id: $(this).val() },
        success: function (result) {
            $("#AirLinePartial").html(result);
            LoadSeats();
        }
    });
});

function LoadSeats () {
    AisleTotalSeats = Number($('#AisleSeats').text());
    MiddleTotalSeats = Number($('#MiddleSeats').text());
    WindowTotalSeats = Number($('#WindowSeats').text());
    TotalPayable = Number($('#SummaryTotal').text());
}

function TxtAisleKeyUP() {
    var Aislechcked = $('#ChkAisle').prop('checked');
    var TextBoxVal = Number($('#TxtAisle').val());
    var SummaryAisleTxt = Number($('#SummaryAisle').text());
    var AvailableSeats = Number($('#AisleSeats').text());
    var AisleUnitPrice = Number($('#AislePrice').text());
    CalculatePricePerSeat(Aislechcked, TextBoxVal, SummaryAisleTxt, AvailableSeats, AisleTotalSeats, AisleUnitPrice, 'SummaryAisle', 'AisleSeats');
    
}

function TxtMiddleKeyUP() {
    var Middlechcked = $('#ChkMiddle').prop('checked');
    var TextBoxVal = Number($('#TxtMiddle').val());
    var SummaryMiddleTxt = Number($('#SummaryMiddle').text());
    var AvailableSeats = Number($('#MiddleSeats').text());
    var MiddleUnitPrice = Number($('#MiddlePrice').text());
    CalculatePricePerSeat(Middlechcked, TextBoxVal, SummaryMiddleTxt, AvailableSeats, MiddleTotalSeats, MiddleUnitPrice, 'SummaryMiddle', 'MiddleSeats');
}

function TxtWindowKeyUP() {
    var Windowchcked = $('#ChkWindow').prop('checked');
    var TextBoxVal = Number($('#TxtWindow').val());
    var SummaryWindowTxt = Number($('#SummaryWindow').text());
    var AvailableSeats = Number($('#WindowSeats').text());
    var WindowUnitPrice = Number($('#WindowPrice').text());
    CalculatePricePerSeat(Windowchcked, TextBoxVal, SummaryWindowTxt, AvailableSeats, MiddleTotalSeats, WindowUnitPrice, 'SummaryWindow', 'WindowSeats');
}
function CalculatePricePerSeat(checkbox, TextBoxVal, SummaryLblVal, AvailableSeatsVal, OrigionalSeats, SeatUnitPrice, SummaryLbl, AvailableSeatLbl) {
    if (checkbox === true && TextBoxVal > 0) {
        if (TextBoxVal > AvailableSeatsVal) {
            alert("Seats are full or not Available for this choice");
            AvailableSeatsVal = AvailableSeatsVal + (OrigionalSeats - AvailableSeatsVal);
            $('#' + AvailableSeatLbl).text(AvailableSeatsVal);

            if (TextBoxVal < AvailableSeatsVal) {
                SummaryLblVal = TextBoxVal;
                AvailableSeatsVal = AvailableSeatsVal - TextBoxVal;
                if (SeatUnitPrice > 0) {
                    $('#' + SummaryLbl).text(SummaryLblVal * SeatUnitPrice);
                }
            }
        } else if (TextBoxVal < AvailableSeatsVal) {
            SummaryLblVal = TextBoxVal;
            AvailableSeatsVal = AvailableSeatsVal - TextBoxVal;
            if (SeatUnitPrice > 0) {
                $('#' + SummaryLbl).text(SummaryLblVal * SeatUnitPrice);
            }

        } else if (TextBoxVal === AvailableSeatsVal) {
            SummaryLblVal = TextBoxVal;
            AvailableSeatsVal = 0;

            if (SeatUnitPrice > 0) {
                $('#' + SummaryLbl).text(SummaryLblVal * SeatUnitPrice);
            } 
        }

        if (AvailableSeatsVal >= 0) {
            $('#' + AvailableSeatLbl).text(AvailableSeatsVal);
        } else {
            alert("Your Selection is higher than Available seats");
            AvailableSeatsVal = AvailableSeatsVal + (OrigionalSeats - AvailableSeatsVal);
            $('#' + AvailableSeatLbl).text(AvailableSeatsVal);
            $('#' + SummaryLbl).text(0);
        }
    }
    if (TextBoxVal === 0 && checkbox === true && SummaryLblVal !== 0) {
        AvailableSeatsVal = Number(AvailableSeatsVal) + Number(SummaryLblVal / SeatUnitPrice);
        $('#' + AvailableSeatLbl).text(AvailableSeatsVal);
        $('#' + SummaryLbl).text(0);
    }

    if (TextBoxVal === 0 && checkbox === true && SummaryLblVal === 0 && AvailableSeatsVal < OrigionalSeats) {
        AvailableSeatsVal = AvailableSeatsVal + (OrigionalSeats - AvailableSeatsVal);
        $('#' + AvailableSeatLbl).text(AvailableSeatsVal);
    }

    CalculateTotalPayable();
}

function CalculateTotalPayable() {
    var Total = TotalPayable;
    Total =Total+Number($('#SummaryAisle').text()) + Number($('#SummaryMiddle').text()) + Number($('#SummaryWindow').text());
    $('#SummaryTotal').text(Total);
}