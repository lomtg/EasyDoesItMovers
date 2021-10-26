$(window).scroll(function(){	
	if($(window).scrollTop() > 1){
		$('body').addClass('scrolled');
		
	}
	else{
		$('body').removeClass('scrolled');
	}
});