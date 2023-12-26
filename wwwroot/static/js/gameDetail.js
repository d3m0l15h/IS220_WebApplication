var GAME_QUANTITY_IN_STOCK = 0;

$(document).ready(() => {
  const qtyInStock = parseInt($("#disc-stock").val());
  GAME_QUANTITY_IN_STOCK = qtyInStock;
  $(".quantity-left-alert-text").text(`${qtyInStock} left in stock`);
  if (qtyInStock < 10) {
    $(".quantity-left-alert").addClass("show");
  } else {
    $(".quantity-left-alert").removeClass("show");
  }
  if (qtyInStock === 0) {
    $(".quantity-left-alert").addClass("show");
    $(".quantity-left-alert-text").text("Out of stock");
    $("#gametype-disc").prop("disabled", true);
  } else {
    $("#gametype-disc").prop("disabled", false);
  }
});

$(".about-table [name=game-type]").click(function () {
  const type = $(this).val();
  if (type === '1') {
    // disc
    $(".about-table .game-quantity").addClass("show");
  } else {
    $(".about-table .game-quantity").removeClass("show");
    $(".about-table .game-quantity input").val("1");
  }
});

$(".about-table [game-action*='change-quantity']").click(function () {
  const q = $(".about-table .game-quantity input");
  const current = parseInt(q.val());
  if (isNaN(current)) {
    q.val(1);
    return;
  }
  if ($(this).attr("game-action") === "change-quantity-minus") {
    if (current > 1) {
      q.val(current - 1);
    } else {
      notyf.error("Quantity must be at least 1");
    }
  }
  if ($(this).attr("game-action") === "change-quantity-plus") {
    if (current + 1 > GAME_QUANTITY_IN_STOCK) {
      notyf.error("Out of stock");
      return;
    }
    q.val(current + 1);
  }
});

$(".about-table .game-quantity input").on("input", function () {
  const current = parseInt($(this).val());
  if (isNaN(current)) {
    $(this).val(1);
    return;
  }
  if (current < 1) {
    $(this).val(1);
    notyf.error("Quantity must be at least 1");
    return;
  }
  if (current > GAME_QUANTITY_IN_STOCK) {
    notyf.error("Out of stock");
    $(this).val(GAME_QUANTITY_IN_STOCK);
  }
});

$(document).ready(function() {
    $('.buy-now').click(function() {
        // Retrieve game details
        var gameId = $('#gameid').val();
        var gameType = $('.about-table [name=game-type]:checked').val();
        var quantity = $('.about-table .game-quantity input').val();

        // Prepare data to be sent
        var gameData = {
            game_id: gameId,
            type: gameType,
            quantity: parseInt(quantity)
        };

        // type is not specified
        if (gameData.type === undefined) {
            return notyf.error("Please select a type of game");
        } else if(gameData.type === '1' && $("#disc-stock").val() === '0'){
            return notyf.error("Out of stock");
        }
        
        // Make AJAX request to add item to cart
        $.ajax({
            method: 'post',
            url: '/carts/add',
            data: gameData,
            success: function(response) {
                // On success, redirect to checkout page
                window.location.href = '/checkout';
            },
            error: function(response) {
                // Handle any errors
                notyf.error('Error adding item to cart:', response);
            }
        });
    });
});