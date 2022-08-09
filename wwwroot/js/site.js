
window.onload=function ()
{

    $('form.categoryForm').each(function () {
        var $this = $(this);
        
        $this.submit(function (e) {
           e.preventDefault();
            $.ajax({
                type: "GET",
                url: "/Products/Server",
                data: "id="+new URLSearchParams(window.location.search).get("id") +"&categoryId=" + $this.find('input:hidden[name="id"]').val()
            });
            window.location.href="?id="+new URLSearchParams(window.location.search).get("id") +"&categoryId=" + $this.find('input:hidden[name="id"]').val();
        });
    });

}

//rcon.send(JSON.stringify(packet));
 //rcon.onerror = function(e){console.log(e)};
 //rcon.onclose = function(e){console.log('close');}