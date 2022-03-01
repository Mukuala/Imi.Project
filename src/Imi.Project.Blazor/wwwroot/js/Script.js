function UpdateList() {

    var puzzleList = [];

    var A = document.querySelectorAll("div.grid-item");
    for (var i = 0; i < A.length; i++) {
        puzzleList.push(A[i].id.replace("puz_",""));
    }
    return puzzleList;
}
function Solved() {
    alert("Puzzle is solved! :)");

}function TimeOut() {
    alert("Failed to solve puzzle in time :(");
}