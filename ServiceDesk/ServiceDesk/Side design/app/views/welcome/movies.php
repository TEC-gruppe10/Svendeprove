<?php
/**
 * Sample layout
 */

use Core\Language;

$sort = (!isset($_GET['sort']) ? "premiere" : $_GET['sort']);
$sorted = ($sort == "premiere") ? false : true;
$page = $data['page'] == null ? 1 : $data['page'];
$genre = (!isset($_GET['genre']) ? null : $_GET['genre']);

$items_per_page = 12;
$index = ($page-1) * $items_per_page; 
$total_records = file_get_contents('http://nepharia.net:1337/api/movies/count');
$total_pages = ceil($total_records / $items_per_page);
$next_page = $page + 1 >= $total_pages ? $total_pages : $page + 1;
$prev_page = $page - 1 <= 0 ? 1 : $page - 1;

if ($genre === null){
    $json = file_get_contents('http://nepharia.net:1337/api/movies/' . $page . '/' . $sort);
}else{
    $json = file_get_contents('http://nepharia.net:1337/api/g/' . $genre);
}
$movies = json_decode($json, TRUE);

?>

<header class="grid fxHeightL">
    <h3 class="grid-cell">
        All <span class="w400">Movies (<?php echo $total_records ?>)</span>
    </h3>
    <div class="grid-cell smHeader">
        <span>Sort: <a <?php echo($sorted ? "class=\"active\"" : "");?> href="<?php echo "/movies/$page&sort=title"?>">Alphabetical</a> / <a <?php echo($sorted ? "" : "class=\"active\"");?> href="<?php echo "/movies/$page&sort=premiere"?>">Premiere</a>
        </span>
    </div>
    <nav class="grid-cell mBoxHeader">
        <ul>
            <?php for ($i = 1; $i <= $total_pages; $i++) {
                $arr[$i] = $i == $page ? "<li><a class=\"active\" href=\"/movies/$i&sort=$sort\">$i</a></li>" : "<li><a href=\"/movies/$i&sort=$sort\">$i</a></li>";
                                    echo $arr[$i];
                                }
                                $arr[$total_pages+1] = "<li><a href=\"/movies/$next_page&sort=$sort\"><i class=\"fa fa-chevron-right\"></i></a></li>";
                                echo $arr[$total_pages+1]; ?>
        </ul>
    </nav>
</header>
<div class="mBoxes black clear">
<?php
for ($i = 0; $i < count($movies); $i++) {
    echo '<div class="mBox">
            <a href="/movie/' . $movies[$i]['Slug'] . '">
                <img img src="/static/img/posters/' . $movies[$i]['Slug'] . '/thumb.jpg" width="253" height="372" />
            </a>
            <a href="/movie/' . $movies[$i]['Slug'] . '">
                <h4>' . $movies[$i]['l'] . '</h4>
            </a>
            <p>' . $movies[$i]['p'] . '</p>
                <button>Order Tickets</button>
            </div>';
}
?> 
</div>
<nav class="mBoxHeader fxHeightL">
    <ul>
        <li><a href=<?php echo "/movies/$prev_page&sort=$sort"?>><i class="fa fa-chevron-left"></i></a></li>
        <?php for ($i = 0; $i <= count($arr); $i++) {echo $arr[$i];} ?>
    </ul>
</nav>