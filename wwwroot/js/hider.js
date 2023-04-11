function myFunction() {
    var x = document.getElementById("Sub");
    if (x.style.display === "none") {
        x.style.display = "block";
    }
    else
    {
        
        var z = $("input#mail").val();
        if (z !== "") {
            x.style.display = "none";
            alert("You Have Subscribed Successfully");
            var y = document.getElementById("next");
            y.textContent = "You Have Already Subscribed";
        }
        else {
            alert("Enter your Email!");
        }

        
    }
}