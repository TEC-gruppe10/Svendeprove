<?php
/**
 * Welcome controller
 *
 * @author David Carr - dave@daveismyname.com
 * @version 2.2
 * @date June 27, 2014
 * @date updated Sept 19, 2015
 */

namespace Controllers;

use Core\View;
use Core\Controller;

/**
 * Sample controller showing a construct and 2 methods and their typical usage.
 */
class Welcome extends Controller
{

    /**
     * Call the parent construct
     */
    public function __construct()
    {
        parent::__construct();
        $this->language->load('Welcome');
    }

    /**
     * Define Index page title and load template files
     */
    public function index()
    {
        $data['title'] = $this->language->get('welcome_text');
        $data['active'] = 0;
        
        View::renderTemplate('header', $data);
        View::render('welcome/welcome', $data);
        View::renderTemplate('footer', $data);
    }
    
    public function movies1()
    {
        $data['title'] = 'View all movies';
        $data['page'] = 1;
        $data['active'] = 1;
            
        View::renderTemplate('header', $data);
        View::render('welcome/movies', $data);
        View::renderTemplate('footer', $data);
    }
    
    public function movies($page)
    {
        $data['title'] = 'View all movies';
        $data['page'] = $page;
        $data['active'] = 1;
            
        View::renderTemplate('header', $data);
        View::render('welcome/movies', $data);
        View::renderTemplate('footer', $data);
    }
    
    public function movie($movie)
    {
        $json = file_get_contents('http://nepharia.net:1337/api/movie/' . $movie);
        $movies = json_decode($json, TRUE);
        
        $data['title'] = $movies[0]['Title'];
        $data['movie'] = $movies;
        
        //Rating (0 - 100)
        if ($movies[0]['Rating'] >= 95){
            $data['movie'][0]['Rating'] = '<span class="ratings five"></span>';
        }
        elseif ($movies[0]['Rating'] >= 85){
            $data['movie'][0]['Rating'] = '<span class="ratings fourhalf"></span>';
        }
        elseif ($movies[0]['Rating'] >= 70){
            $data['movie'][0]['Rating'] = '<span class="ratings four"></span>';
        }
        elseif ($movies[0]['Rating'] >= 60){
            $data['movie'][0]['Rating'] = '<span class="ratings threehalf"></span>';
        }
        elseif ($movies[0]['Rating'] >= 50){
            $data['movie'][0]['Rating'] = "<span class=\"ratings three\"></span>";
        }
        elseif ($movies[0]['Rating'] >= 40){
            $data['movie'][0]['Rating'] = "<span class=\"ratings twohalf\"></span>";
        }
        elseif ($movies[0]['Rating'] >= 30){
            $data['movie'][0]['Rating'] = "<span class=\"ratings two\"></span>";
        }
        elseif ($movies[0]['Rating'] >= 20){
            $data['movie'][0]['Rating'] = "<span class=\"ratings onehalf\"></span>";
        }
        elseif ($movies[0]['Rating'] >= 10){
            $data['movie'][0]['Rating'] = "<span class=\"ratings one\"></span>";
        }
        elseif ($movies[0]['Rating'] >= 1){
            $data['movie'][0]['Rating'] = "<span class=\"ratings\"></span>";
        }
        else{
            $data['movie'][0]['Rating'] = "Not yet rated";
        }
        
        
            
        View::renderTemplate('header', $data);
        View::render('welcome/movie', $data);
        View::renderTemplate('footer', $data);
    }
    
    public function typography()
    {
        $data['title'] = 'Typography';
        $data['active'] = 2;
        
        View::renderTemplate('header', $data);
        View::render('welcome/typography', $data);
        View::renderTemplate('footer', $data);
    }
}
