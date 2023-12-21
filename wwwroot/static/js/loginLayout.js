const userSetting = document.querySelector(".user-setting");

userIcon.onclick = () => {
  userSetting.classList.toggle("active");
};

document.onclick = (e) => {
  if (!userIcon.contains(e.target) && !userSetting.contains(e.target))
    userSetting.classList.remove("active");
};

document
  .querySelector("#cartOffcanvas")
  .addEventListener("shown.bs.offcanvas", (e) => {
    document.body.style.overflow = "hidden";
    document.documentElement.style.overflow = "hidden";
  });

document
  .querySelector("#cartOffcanvas")
  .addEventListener("hidden.bs.offcanvas", (e) => {
    document.body.style.overflow = "auto";
    document.documentElement.style.overflow = "auto";
  });

function getImageUrl(imgPath) {
  return `/images/game/${imgPath}`;
}

function renderCart(items = []) {
  const cartBody = $("#cartOffcanvas .offcanvas-body");
  const cartQty = $(".cart-button .cart-quantity");
  cartBody.html("");
  cartQty.parent().addClass("visually-hidden");
  if (!items || !Array.isArray(items)) {
    cartBody.html(`
            <div class="d-flex justify-content-center align-items-center" style="height: 100%;">
                <h5 class="text-center">Cart empty</h5>
            </div>
        `);
    return notyf.error("Có lỗi xảy ra");
  }
  if (!items.length) {
    return cartBody.html(`
            <div class="d-flex justify-content-center align-items-center" style="height: 100%;">
                <h5 class="text-center">Cart empty</h5>
            </div>
        `);
  }
  const total = items.length;
  const html = items
    .map((item) => {
      return `<div class="cart-item d-flex justify-content-between align-items-center">
                    <div class="col-md-2 col-lg-2 col-xl-2 d-flex justify-content-center">
                        <img src="${getImageUrl(
                          item.gameImg
                        )}" class="img-fluid rounded-3" alt="">
                    </div>
                    <div class="col-md-6 col-lg-6 col-xl-6 px-2">
                        <div>
                            <h6><span class="badge bg-secondary">Software</span> ${
                              item.gameTitle
                            }</h6>
                        </div>
                        <div class="quantity-input mt-2">
                            <button class="btn btn-icon text-white" game-action="change-quantity-minus">-</button>
                            <input type="text" game-input="quantity" value="1">
                            <button class="btn btn-icon text-white" game-action="change-quantity-plus">+</button>
                        </div>
                    </div>
                    <div class="col-md-3 col-lg-1 col-xl-2 d-flex justify-content-center">
                        <h6 class="mb-0">${Number(
                          item.gamePrice
                        ).toLocaleString("vi")}đ</h6>
                    </div>
                    <div class="col-md-1 col-lg-1 col-xl-1 ms-3">
                        <a href="#!" class="btn btn-icon btn-outline-danger" game-action="remove-cart" game-target="${
                          item.gameId
                        }">
                            <i class='bx bx-trash-alt'></i>
                        </a>
                    </div>
                </div>
                <hr class="my-4">`;
    })
    .join("");
  if (html) {
    cartBody.html(html);
    if (total > 99) {
      cartQty.text("99+");
    } else {
      cartQty.text(total);
    }
    cartQty.parent().removeClass("visually-hidden");
  }
}

function syncCart() {
  $.ajax({
    method: "get",
    url: "/carts/get",
    encode: true,
  }).done((items) => {
    renderCart(items);
  });
}
syncCart();

$('[game-action="add-cart"]').click(() => {
  const gameData = {
    game_id: $("#gameid").val(),
    type: $("[name=game-type]:checked").val(),
    quantity: parseInt($(".about-table .game-quantity input").val()),
  };
  $.ajax({
    method: "post",
    url: "/carts/add",
    encode: true,
    data: gameData,
  }).done((d) => {
    notyf.success(d);
    syncCart();
    new bootstrap.Offcanvas("#cartOffcanvas").show();
  });
});

$(document).on("click", '[game-action="remove-cart"]', function () {
  const gameData = {
    game_id: $(this).attr("game-target"),
    quantity: null,
  };
  $.ajax({
    method: "post",
    url: "/carts/remove",
    encode: true,
    data: gameData,
  }).done((d) => {
    notyf.success(d);
    syncCart();
  });
});

$(document).on("click", '[game-action*="change-quantity"]', function () {
  const q = $(this).siblings('[game-input="quantity"]').first();
  const current = parseInt(q.val());
  if (isNaN(current)) {
    q.val(1);
    return;
  }
  if ($(this).attr("game-action") == "change-quantity-minus") {
    if (current > 1) {
      q.val(current - 1);
    } else {
      notyf.error("Quantity must be at least 1");
    }
  }
  if ($(this).attr("game-action") == "change-quantity-plus") {
    q.val(current + 1);
  }
});

$(document).on("input", '.quantity-input [game-input="quantity"]', function () {
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
});
