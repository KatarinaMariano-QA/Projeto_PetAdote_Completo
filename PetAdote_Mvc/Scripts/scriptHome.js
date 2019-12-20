
debounce = function(func, wait, immediate) {
	var timeout;
	return function() {
		var context = this, args = arguments;
		var later = function() {
			timeout = null;
			if (!immediate) func.apply(context, args);
		};
		var callNow = immediate && !timeout;
		clearTimeout(timeout);
		timeout = setTimeout(later, wait);
		if (callNow) func.apply(context, args);
	};
};


(function(){
	var $target = $('.animated'),
			offset = $(window).height() * 3/4;

	function animeScroll() {
		var documentTop = $(document).scrollTop();

		$target.each(function(){
			var itemTop = $(this).offset().top;
			if (documentTop > itemTop - offset) {
				if($(this).hasClass("left")){
					$(this).addClass("ativo slideInLeft");
				}
				else if($(this).hasClass("right")){
					$(this).addClass("ativo slideInRight");
				}
				else if($(this).hasClass("Zoom")){
					$(this).addClass("ativo zoomIn");
				}
				else if($(this).hasClass("cair")){
					$(this).addClass("ativo fadeInDown");
				}
				else if($(this).hasClass("subir")){
					$(this).addClass("ativo fadeInUp");
				}
				else if($(this).hasClass("foot")){
					$(this).addClass("ativo flash");
					
				}
				else if($(this).hasClass("rubber")){
					$(this).addClass("ativo rubberBand");
					
				}
				else if($(this).hasClass("balance")){
					$(this).addClass("ativo shake");
					
				}
				else if($(this).hasClass("fadeIn")){
					$(this).addClass("ativo fadeIn");
					
				}
			}
			
			if (itemTop > offset) {
				if($(this).hasClass("foot")){
					$(this).addClass("ativo flash");
				}
				
			}
		});
	}

	animeScroll();

	$(document).scroll(debounce(function(){
		animeScroll();
	}, 200));
})();

