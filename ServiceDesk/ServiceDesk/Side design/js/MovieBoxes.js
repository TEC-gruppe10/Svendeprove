$(document).ready(function(page,index,items_per_page,prev_page,next_page,total_pages){
    $(function(){
        $.ajax({
            url: '/php-scripts/moviebox.php?page=' + page + '&out=1&index=' + index + '&items_per_page=' + items_per_page,
            dataType: "json",
            success: function (data) {
                for (i = 0; i < data.length; i++) {
                    var FilmURL = data[i][0];
                    var Titel = data[i][1];
                    var Cover = data[i][2];
                    var Premiere = data[i][3];
                    $(".MovieBoxes").append(
                        '<div class="col-5 MovieBox"><div class="col-1"><a href="' +
                        FilmURL + '"><div class="bgBox" style="background-image:url(' +
                        Cover + ')"></div><a href="' +
                        FilmURL + '"><h3>' +
                        Titel + '</h3></a><p>' +
                        Premiere + '</p><a href="' +
                        FilmURL + '"><button>Se mere info</button></a></div></div>'
                    )
                }
            }
        })
    })
    $(".MovieBoxHeaderStyle nav ul li a").click(function(event){
        event.preventDefault();
    })
});