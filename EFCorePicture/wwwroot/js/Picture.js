$(() => {
    setInterval(() => {
        var Id = $("#button").val();
        $.get(`/home/GetLikes?Id=${Id}`, function (id) {
            $("#likes").text(id.number);
        })
    }, 1000)

    $("#button").on('click', function () {
        var Id = $("#button").val();
        $.post(`/Home/AddLikes?Id=${Id}`, function (p) {
            $(".button").prop("disabled", true);
        })
    })
})