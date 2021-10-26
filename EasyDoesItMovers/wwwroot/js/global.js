$(function(){
	$('header .hamburger').click(function () {
		$('header').toggleClass('nav-opened');
		$('header nav').slideToggle(300);
        return false;
    });
	
});

$(window).scroll(function(){	
	if($(window).scrollTop() > 1){
		$('body').addClass('scrolled');
		
	}
	else{
		$('body').removeClass('scrolled');
	}
});



$(window).on('load', function(){
	//animation to elements on scroll
	if (jQuery().appear) {
		jQuery('.to_animate').appear();
		jQuery('.to_animate').filter(':appeared').each(function(index){
			var self = jQuery(this);
			var animationClass = !self.data('animation') ? 'fadeInUp' : self.data('animation');
			var animationDelay = !self.data('delay') ? 210 : self.data('delay');
			setTimeout(function(){
				self.addClass("animated " + animationClass);
			}, index * animationDelay);
		});

		jQuery('body').on('appear', '.to_animate', function(e, $affected ) {
			jQuery($affected).each(function(index){
				var self = jQuery(this);
				var animationClass = !self.data('animation') ? 'fadeInUp' : self.data('animation');
				var animationDelay = !self.data('delay') ? 210 : self.data('delay');
				setTimeout(function(){
					self.addClass("animated " + animationClass);
				}, index * animationDelay);
			});
		});
	} //appear check
});


