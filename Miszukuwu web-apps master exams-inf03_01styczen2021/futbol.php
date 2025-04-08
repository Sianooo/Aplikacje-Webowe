<?php
// Connect to the database
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "football";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// Query to retrieve data
$sql = "SELECT zespol1, zespol2, wynik, data_rozgrywki FROM rozgrywka"; // Updated field names
$result = $conn->query($sql);

// Check if there are results
if ($result) {
    if ($result->num_rows > 0) {
        // Output data for each row
        while($row = $result->fetch_assoc()) {
            echo "<section>";
            echo "<h3>" . $row["zespol1"] . " - " . $row["zespol2"] . "</h3>";
            echo "<h4>" . $row["wynik"] . "</h4>";
            echo "<p>w dniu: " . $row["data_rozgrywki"] . "</p>";
            echo "</section>";
        }
    } else {
        echo "0 results";
    }
} else {
    echo "Error: " . $conn->error; // Display SQL error if the query fails
}

if (!empty($_POST['position_id'])) {
    $position_id = $_POST['position_id'];
    $sql2 = "SELECT imie, nazwisko FROM zawodnik WHERE pozycja_id = $position_id"; // Adjust the table name and fields as necessary
    $result2 = $conn->query($sql2);

    // Check if there are results
    if ($result2) {
        if ($result2->num_rows > 0) {
            echo "<ul>";
            while($row2 = $result2->fetch_assoc()) {
                echo "<li>" . $row2["imie"] . " " . $row2["nazwisko"] . "</li>";
            }
            echo "</ul>";
        } else {
            echo "No players found for this position.";
        }
    } else {
        echo "Error: " . $conn->error; // Display SQL error if the query fails
    }
}

// Close the connection
$conn->close();
?>
