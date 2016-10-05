<?php
/**
 * Sample layout
 */

use Helpers\Assets;
use Helpers\Url;
use Helpers\Hooks;

//initialise hooks
$hooks = Hooks::get();
?>

</main>


    <footer class="light">
        <div class="social">
            <div class="one"><a class="logo" href="/"><h3>Nepharia</h3></a></div><div class="two">
                <a href="#TopMenu" title="Go to top"><i class="fa fa-2x fa-angle-up"></i></a>
            </div><div class="three">
                <a href="#" title="Facebook profile"><i class="fa fa-facebook-square fa-2x"></i></a>
                <a href="#" title="LindedIn profile"><i class="fa fa-linkedin-square fa-2x"></i></a>
                <a href="#" title="Twitter profile"><i class="fa fa-twitter-square fa-2x"></i></a>
            </div>
        </div>
    </footer>

<!-- JS -->
<?php
Assets::js(array(
    'https://code.jquery.com/jquery-1.11.3.min.js',
	'/static/js/script.js',
    
));

//hook for plugging in javascript
$hooks->run('js');

//hook for plugging in code into the footer
$hooks->run('footer');
?>

</body>
</html>
