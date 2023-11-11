(function ($) {
    'use strict';

    // navbarDropdown
    if ($(window).width() < 992) {
        $('.navigation .dropdown-toggle').on('click', function () {
            $(this).siblings('.dropdown-menu').animate({
                height: 'toggle'
            }, 300);
        });
    }

    // scroll to top button
    $(window).on('scroll', function () {
        if ($(window).scrollTop() > 70) {
            $('.backtop').addClass('reveal');
        } else {
            $('.backtop').removeClass('reveal');
        }
    });

    // scroll-to-top
    $('.scroll-top-to').on('click', function () {
        $('body,html').animate({
            scrollTop: 0
        }, 500);
        return false;
    });

    $('.portfolio-single-slider, .clients-logo, .testimonial-wrap, .testimonial-wrap-2').slick({
        infinite: true,
        arrows: false,
        autoplay: true,
        responsive: [
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 6,
                    slidesToScroll: 6,
                    dots: true
                }
            },
            {
                breakpoint: 900,
                settings: {
                    slidesToShow: 4,
                    slidesToScroll: 4
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }
        ]
    });

    // counter
    function counter() {
        var oTop;
        if ($('.counter').length !== 0) {
            oTop = $('.counter').offset().top - window.innerHeight;
        }
        if ($(window).scrollTop() > oTop) {
            $('.counter').each(function () {
                var $this = $(this),
                    countTo = $this.attr('data-count');
                $({
                    countNum: $this.text()
                }).animate({
                    countNum: countTo
                }, {
                    duration: 500,
                    easing: 'swing',
                    step: function () {
                        $this.text(Math.floor(this.countNum));
                    },
                    complete: function () {
                        $this.text(this.countNum);
                    }
                });
            });
        }
    }

    $(window).on('scroll', counter);

    function setActiveButton(element) {
        var buttons = document.querySelectorAll('.btn');
        buttons.forEach(function (btn) {
            btn.classList.remove('active');
        });

        element.parentElement.classList.add('active');
    }

    // Shuffle js filter and masonry
    if ($('.shuffle-wrapper').length !== 0) {
        var Shuffle = window.Shuffle;
        var jQuery = window.jQuery;

        var myShuffle = new Shuffle(document.querySelector('.shuffle-wrapper'), {
            itemSelector: '.shuffle-item',
            buffer: 1
        });

        $('#allFilter, #cat1Filter').on('change', function (evt) {
            var input = evt.currentTarget;
            if (input.checked) {
                setActiveButton(input);
                myShuffle.filter(input.value);
            }
        });
    }

})(jQuery);
