<?php
/**
 * Sample layout
 */

use Core\Language;

?>

<div class="clear">
    <div class="col-7 cover">
    <a class="fancybox" href="/static/img/posters/<?php echo $data['movie'][0]['Slug'] ?>/large.jpg"><img src="/static/img/posters/<?php echo $data['movie'][0]['Slug'] ?>/small.jpg" /></a>
</div>
<div class="col-5 cover">
    <h1><?php echo $data['movie'][0]['Title'] ?><span class="w500"> (<?php echo $data['movie'][0]['y'] ?>)</span></h1>
            <ul class="cover info">
            <li>
                <b>Genre:</b><span>
                   <?php 
                        $gCount = count($data['movie']);
                        for($i = 0; $i < $gCount; ++$i){
                            echo '<a href="/movies/&genre=' . $data['movie'][$i]['Genre'] . '">' . $data['movie'][$i]['Genre'] . '</a>';
                                    if($i != ($gCount - 1))
                                       echo ", ";
                        }
                    ?>
                </span>
            </li>
     <li><b>Rating:</b> <?php echo $data['movie'][0]['Rating']; ?></li>
        <li><b> PlayTime: </b><span><i class="fa fa-time"></i> <?php echo $data['movie'][0]['p']; ?></span></li>
    </ul>   
    <ul class="FancyLinks">
        <li>
            <span><i class="fa fa-ticket"></i><a href="#">Order tickets</a></span> 
        </li>
        <li>
            <span><i class="fa fa-youtube-play red"></i><a class="fancybox fancybox.iframe" href="https://www.youtube.com/v/<?php echo $data['movie'][0]['Trailer']; ?>&rel=1&autoplay=1">Watch Trailer</a></span>
        </li>
    </ul>
    <div class="cover info">
        <p><?php echo nl2br($data['movie'][0]['Descrip']); ?></p>
    </div>
</div>
</div>
