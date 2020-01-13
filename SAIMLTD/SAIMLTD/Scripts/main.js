$.noConflict();

jQuery(document).ready(function($) {

	"use strict";

	[].slice.call( document.querySelectorAll( 'select.cs-select' ) ).forEach( function(el) {
		new SelectFx(el);
	});

	jQuery('.selectpicker').selectpicker;


	

	$('.search-trigger').on('click', function(event) {
		event.preventDefault();
		event.stopPropagation();
		$('.search-trigger').parent('.header-left').addClass('open');
	});

	$('.search-close').on('click', function(event) {
		event.preventDefault();
		event.stopPropagation();
		$('.search-trigger').parent('.header-left').removeClass('open');
	});

	$('.equal-height').matchHeight({
		property: 'max-height'
	});

	// var chartsheight = $('.flotRealtime2').height();
	// $('.traffic-chart').css('height', chartsheight-122);


	// Counter Number
	$('.count').each(function () {
		$(this).prop('Counter',0).animate({
			Counter: $(this).text()
		}, {
			duration: 3000,
			easing: 'swing',
			step: function (now) {
				$(this).text(Math.ceil(now));
			}
		});
	});


	 
	 
	// Menu Trigger
	$('#menuToggle').on('click', function(event) {
		var windowWidth = $(window).width();   		 
		if (windowWidth<1010) { 
			$('body').removeClass('open'); 
			if (windowWidth<760){ 
				$('#left-panel').slideToggle(); 
			} else {
				$('#left-panel').toggleClass('open-menu');  
			} 
		} else {
			$('body').toggleClass('open');
			$('#left-panel').removeClass('open-menu');  
		} 
			 
	}); 

	 
	$(".menu-item-has-children.dropdown").each(function() {
		$(this).on('click', function() {
			var $temp_text = $(this).children('.dropdown-toggle').html();
			$(this).children('.sub-menu').prepend('<li class="subtitle">' + $temp_text + '</li>'); 
		});
	});


	// Load Resize 
	$(window).on("load resize", function(event) { 
		var windowWidth = $(window).width();  		 
		if (windowWidth<1010) {
			$('body').addClass('small-device'); 
		} else {
			$('body').removeClass('small-device');  
		} 
		
	});
  
	$('#export').on('click', function () {
		var export_button = document.getElementById('export');
		if (export_button) {
			export_button.setAttribute('disabled', 'disabled');
			export_button.innerHTML = "<i class='fa fa-spinner fa-pulse'></i> Export en cours...";
			$.ajax({
				type: "GET",
				url: "/customer/prepare_export",
				contentType: "application/json; charset=utf-8",
				success: function (result) {
					if (result.Status === 1) {
						export_button.innerHTML = "<a href='" + result.Chemin + "' download style='color: white;'><i class='fa fa-download'></i> Telecharger</a>";
						export_button.removeAttribute("disabled");
						export_button.removeAttribute("id");
						export_button.setAttribute("style", "float: right;");
					}
					else if (result.Status === 0) {
						export_button.innerHTML = "<i class='fa fa-times-circle' style='color: red;'></i> Echec de l'export, reesayer?";
						export_button.removeAttribute("disabled");
						console.log(result.message);
					}
				},
				error: function (err) {
					
				}
			});
		}
	}); 
});