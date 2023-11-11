function printSection() {
    var section = document.getElementById("tableprint");
    var printContents = section.innerHTML;
    var originalContents = document.body.innerHTML;

    document.body.innerHTML = printContents;
    window.print();
    document.body.innerHTML = originalContents;
}