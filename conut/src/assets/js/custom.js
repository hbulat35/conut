
$(document).ready(function(){
  // home 1
//  if ($(".multiple-items")[0]){
//  $('.multiple-items').slick({
//   infinite: true,
//   slidesToShow: 1,
//   dots: true,
//   arrow: false,
//   autoplay: true,
//   autoplaySpeed: 2000,
//   slidesToScroll: 1
// });
// }
if ($(".center")[0]){
 $('.center').slick({
  infinite: true,
  slidesToShow: 1,
  autoplay: true,
  autoplaySpeed: 2000,
  slidesToScroll: 1
  });
}
// home 4
if ($(".page-for")[0]){
$('.page-for').slick({
  infinite: true,
  slidesToShow: 1,
  dots: false,
  arrow: true,
  autoplay: true,
  autoplaySpeed: 2000,
  slidesToScroll: 1
});
}
if ($(".post-for")[0]){
$('.post-for').slick({
  infinite: true,
  slidesToShow: 1,
  slidesToScroll: 1,
  arrow: false,
  autoplay: true,
  autoplaySpeed: 2000,
  dots: true,
});
}
// blog 4
if ($(".slider-for-blog")[0]){
 $('.slider-for-blog').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
  arrows: false,
  fade: true,
  asNavFor: '.slider-nav-blog'
});
}
if ($(".slider-nav-blog")[0]){
$('.slider-nav-blog').slick({
  slidesToShow: 5,
  slidesToScroll: 1,
  asNavFor: '.slider-for-blog',
  focusOnSelect: true,
  responsive: [
    {
      breakpoint: 768,
      settings: {
        slidesToShow: 3
      }
    },
    {
      breakpoint: 480,
      settings: {
        
        slidesToShow: 2
      }
    }
  ]
});  
}


})

// PRELOADER
if ($("body")[0]) {
  $(window).on('load', function() {
    $("body").addClass("page-loaded");
  });
}

// Responsive header menu
$(document).ready(function(){
 

          jQuery('.mobile-nav .menu-item-has-children').on('click', function($) {

          jQuery(this).toggleClass('active');

        }); 



        jQuery('#nav-icon4').click(function($){

           // jQuery(this).toggleClass('open');

            jQuery('#mobile-nav').toggleClass('open');

        });



        jQuery('#res-cross').click(function($){

           jQuery('#mobile-nav').removeClass('open');

            //jQuery('#nav-icon4').removeClass('open')

        });


        jQuery('.bar-menu').click(function($){

           // jQuery(this).toggleClass('open');

            jQuery('#mobile-nav').toggleClass('open');
            jQuery('#mobile-nav').toggleClass('hmburger-menu');
            jQuery('#mobile-nav').show();

        });



        jQuery('#res-cross').click(function($){

           jQuery('#mobile-nav').removeClass('open');

            //jQuery('#nav-icon4').removeClass('open')

        });
});

// ===== Scroll to Top ==== 
$(window).scroll(function() {
    if ($(this).scrollTop() >= 50) {        // If page is scrolled more than 50px
        $('#return-to-top').fadeIn(200);    // Fade in the arrow
    } else {
        $('#return-to-top').fadeOut(200);   // Else fade out the arrow
    }
});
$('#return-to-top').click(function() {      // When arrow is clicked
    $('body,html').animate({
        scrollTop : 0                       // Scroll to top of body
    }, 500);
});

