function toQuery(str) {
  str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
  str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
  str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
  str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
  str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
  str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
  str = str.replace(/đ/g, "d");
  str = str.replace(/À|Á|Ạ|Ả|Ã|Â|Ầ|Ấ|Ậ|Ẩ|Ẫ|Ă|Ằ|Ắ|Ặ|Ẳ|Ẵ/g, "A");
  str = str.replace(/È|É|Ẹ|Ẻ|Ẽ|Ê|Ề|Ế|Ệ|Ể|Ễ/g, "E");
  str = str.replace(/Ì|Í|Ị|Ỉ|Ĩ/g, "I");
  str = str.replace(/Ò|Ó|Ọ|Ỏ|Õ|Ô|Ồ|Ố|Ộ|Ổ|Ỗ|Ơ|Ờ|Ớ|Ợ|Ở|Ỡ/g, "O");
  str = str.replace(/Ù|Ú|Ụ|Ủ|Ũ|Ư|Ừ|Ứ|Ự|Ử|Ữ/g, "U");
  str = str.replace(/Ỳ|Ý|Ỵ|Ỷ|Ỹ/g, "Y");
  str = str.replace(/Đ/g, "D");
  str = str.replace(/\u0300|\u0301|\u0303|\u0309|\u0323/g, ""); // ̀ ́ ̃ ̉ ̣  huyền, sắc, ngã, hỏi, nặng
  str = str.replace(/\u02C6|\u0306|\u031B/g, ""); // ˆ ̆ ̛  Â, Ê, Ă, Ơ, Ư
  str = str.replace(/ + /g, "");
  str = str.replace(/\s/g, "");
  str = str.toLowerCase();
  str = str.trim();
  str = str.replace(
    /!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'|\"|\&|\#|\[|\]|~|\$|_|`|-|{|}|\||\\/g,
    ""
  );
  return str;
}

function httpGet(theUrl) {
  var xmlHttp = new XMLHttpRequest();

  xmlHttp.open("GET", theUrl, false);
  xmlHttp.setRequestHeader("Access-Control-Allow-Origin", "*");
  xmlHttp.send(null);
  return xmlHttp.responseText;
}

var dvhcData = [];
var pdaData = {};
fetch("/dvhc.json")
  .then((response) => response.json())
  .then((data) => {
    dvhcData = data;
    proSearch();
    disSearch();
    warSearch();
  })
  .catch((error) => {
    console.error("Error:", error);
  });

function proSearch() {
  $(".province").each(function () {
    var $provinceList = $('<ul class="dropdown-menu province-list"></ul>');
    for (i in dvhcData["province"]) {
      var dpro = dvhcData["province"][i]["name"],
        dproid = dvhcData["province"][i]["id"];
      $provinceList.append(
        '<li><a class="dropdown-item" onclick="' +
          "addpda('province', '" +
          dpro +
          "', {'province_id': '" +
          dproid +
          "'}); disSearch()" +
          '">' +
          dpro +
          "</a></li>"
      );
    }
    $(this).after($provinceList);
    disSearch();
  });
}

function disSearch() {
  $(".district").each(function () {
    var dis = $(this).val();
    var $districtList = $('<ul class="district-list dropdown-menu"></ul>');
    if ($(".province").val()) {
      if (pdaData["province_id"]) {
        for (i in dvhcData["province"]) {
          if (pdaData["province_id"] == dvhcData["province"][i]["id"]) {
            for (j in dvhcData["province"][i]["district"]) {
              var d = dvhcData["province"][i]["district"][j]["name"],
                did = dvhcData["province"][i]["district"][j]["id"];
              if (dis) {
                if (toQuery(d).indexOf(toQuery(dis)) >= 0) {
                  $districtList.append(
                    '<li><a class="dropdown-item" onclick="' +
                      "addpda('district', '" +
                      d +
                      "', {'district_id': '" +
                      did +
                      "'}); warSearch()" +
                      '">' +
                      d +
                      "</a></li>"
                  );
                }
              } else {
                $districtList.append(
                  '<li><a class="dropdown-item" onclick="' +
                    "addpda('district', '" +
                    d +
                    "', {'district_id': '" +
                    did +
                    "'}); warSearch()" +
                    '">' +
                    d +
                    "</a></li>"
                );
              }
            }
          }
        }
      } else {
        $districtList.append(
          '<li><a class="dropdown-item">Vui lòng chọn Tỉnh/Thành</a></li>'
        );
      }
    } else {
      pdaData["province_id"] = "";
      $districtList.append(
        '<li><a class="dropdown-item">Vui lòng chọn Tỉnh/Thành</a></li>'
      );
    }
    $(this).after($districtList);
    warSearch();
  });
}

function warSearch() {
  $(".ward").each(function () {
    var war = $(this).val();
    var $wardList = $('<ul class="ward-list dropdown-menu"></ul>');

    if ($(".district").val() && $(".province").val()) {
      if (pdaData["province_id"] && pdaData["district_id"]) {
        for (i in dvhcData["province"]) {
          if (pdaData["province_id"] == dvhcData["province"][i]["id"]) {
            for (j in dvhcData["province"][i]["district"]) {
              if (
                pdaData["district_id"] ==
                dvhcData["province"][i]["district"][j]["id"]
              ) {
                for (k in dvhcData["province"][i]["district"][j]["ward"]) {
                  var d =
                      dvhcData["province"][i]["district"][j]["ward"][k]["name"],
                    did =
                      dvhcData["province"][i]["district"][j]["ward"][k]["id"];
                  if (war) {
                    if (toQuery(d).indexOf(toQuery(war)) >= 0) {
                      $wardList.append(
                        '<li><a class="dropdown-item" onclick="' +
                          "addpda('ward', '" +
                          d +
                          "', {'ward_id': '" +
                          did +
                          "'});" +
                          '">' +
                          d +
                          "</a></li>"
                      );
                    }
                  } else {
                    $wardList.append(
                      '<li><a class="dropdown-item" onclick="' +
                        "addpda('ward', '" +
                        d +
                        "', {'ward_id': '" +
                        did +
                        "'});" +
                        '">' +
                        d +
                        "</a></li>"
                    );
                  }
                }
              }
            }
          }
        }
      } else {
        $wardList.append(
          '<li><a class="dropdown-item">Vui lòng chọn Quận/Huyện</a></li>'
        );
      }
    } else {
      if (!$(".province").val()) {
        pdaData["province_id"] = "";
      }
      if (!$(".district").val()) {
        pdaData["district_id"] = "";
      }
      $wardList.append(
        '<li><a class="dropdown-item">Vui lòng chọn Quận/Huyện</a></li>'
      );
    }
    $(this).after($wardList);
  });
}

function addpda(id, val, d) {
  $("." + id).val(val);
  var prop = id + "_id",
    res = "";
  pdaData[prop] = d[prop];
  for (ig in pdaData) {
    if (pdaData[ig]) {
      switch (ig) {
        case "province_id":
          res += "Mã tỉnh/thành: " + pdaData[ig];
          break;
        case "district_id":
          res += ", quận/huyện: " + pdaData[ig];
          break;
        case "ward_id":
          res += ", phường/xã: " + pdaData[ig];
          break;
      }
    }
  }
  if (res) {
    $("#diaphuong_result").text(res);
  } else {
    $("#diaphuong_result").text("");
  }
  if (id == "province") {
    $(".district").val("");
    $(".ward").val("");
    pdaData["district_id"] = "";
    pdaData["ward_id"] = "";
    setTimeout(disSearch, 100);
  }
  if (id == "district") {
    $(".ward").val("");
    pdaData["ward_id"] = "";
    setTimeout(function () {
      warSearch(pdaData["district_id"]);
    }, 100);
  }
}

function dvhccodeSearch() {
  var d = $("#dvhc_code").val(),
    res = [];

  switch ($("#dvhc_code_type").val()) {
    case "province":
      if (d) {
        if (d.length > 2) {
          res.push(["text", "Nhập tối đa 2 ký tự !"]);
        } else {
          for (i in dvhcData["province"]) {
            if (dvhcData["province"][i]["id"].indexOf(d) >= 0) {
              res.push([
                dvhcData["province"][i]["id"],
                dvhcData["province"][i]["name"],
              ]);
            }
          }
        }
      }
      break;
    case "district":
      if (d) {
        if (d.length > 3) {
          res.push(["text", "Nhập tối đa 3 ký tự !"]);
        } else {
          for (i in dvhcData["province"]) {
            for (j in dvhcData["province"][i]["district"]) {
              if (
                dvhcData["province"][i]["district"][j]["id"].indexOf(d) >= 0
              ) {
                res.push([
                  dvhcData["province"][i]["id"],
                  dvhcData["province"][i]["name"],
                  dvhcData["province"][i]["district"][j]["id"],
                  dvhcData["province"][i]["district"][j]["name"],
                ]);
              }
            }
          }
        }
      }
      break;
    case "ward":
      if (d) {
        if (d.length > 5) {
          res.push(["text", "Nhập tối đa 5 ký tự !"]);
        } else if (d.length > 2) {
          for (i in dvhcData["province"]) {
            for (j in dvhcData["province"][i]["district"]) {
              for (k in dvhcData["province"][i]["district"][j]["ward"]) {
                if (
                  dvhcData["province"][i]["district"][j]["ward"][k][
                    "id"
                  ].indexOf(d) >= 0
                ) {
                  res.push([
                    dvhcData["province"][i]["id"],
                    dvhcData["province"][i]["name"],
                    dvhcData["province"][i]["district"][j]["id"],
                    dvhcData["province"][i]["district"][j]["name"],
                    dvhcData["province"][i]["district"][j]["ward"][k]["id"],
                    dvhcData["province"][i]["district"][j]["ward"][k]["name"],
                  ]);
                }
              }
            }
          }
        } else {
          res.push(["text", "Vui lòng nhập tối thiểu 3 ký tự !"]);
        }
      }
      break;
    case "plate":
      if (d) {
        if (d.length > 2) {
          res.push(["text", "Nhập tối đa 2 ký tự !"]);
        } else if (d == "80") {
          res.push(["80", "Các đơn vị, cơ quan cấp trung ương"]);
        } else {
          for (i in dvhcData["province"]) {
            var plate = dvhcData["province"][i]["plate"];
            for (j in plate) {
              if (plate[j].toString().indexOf(d) >= 0) {
                res.push([plate.join(", "), dvhcData["province"][i]["name"]]);
                break;
              }
            }
          }
        }
      }
      break;
  }

  if (res.length > 0) {
    if (res[0][0] != "text") {
      switch ($("#dvhc_code_type").val()) {
        case "province":
          var t =
            '<table class="table table-striped table-hover"><thead><tr><th>Mã</th><th>Tên</th></tr></thead>';
          for (i in res) {
            t +=
              "<tr><td>" +
              res[i][0] +
              "</td>" +
              "<td>" +
              res[i][1] +
              "</td></tr>";
          }
          t += "</table>";
          $("#dvhc_code_result").html(t);
          break;
        case "district":
          var t =
            '<table class="table table-striped table-hover"><thead><tr><th>Mã</th><th>Tỉnh/Thành</th><th>Mã</th><th>Quận/Huyện</th></tr></thead>';
          for (i in res) {
            t +=
              "<tr><td>" +
              res[i][0] +
              "</td>" +
              "<td>" +
              res[i][1] +
              "<td>" +
              res[i][2] +
              "<td>" +
              res[i][3] +
              "</td></tr>";
          }
          t += "</table>";
          $("#dvhc_code_result").html(t);
          break;
        case "ward":
          var t =
            '<table class="table table-striped table-hover"><thead><tr><th>Mã</th><th>Tỉnh/Thành</th><th>Mã</th><th>Quận/Huyện</th><th>Mã</th><th>Phường/Xã</th></tr></thead>';
          for (i in res) {
            t +=
              "<tr><td>" +
              res[i][0] +
              "</td>" +
              "<td>" +
              res[i][1] +
              "<td>" +
              res[i][2] +
              "<td>" +
              res[i][3] +
              "<td>" +
              res[i][4] +
              "<td>" +
              res[i][5] +
              "</td></tr>";
          }
          t += "</table>";
          $("#dvhc_code_result").html(t);
          break;
        case "plate":
          var t =
            '<table class="table table-striped table-hover"><thead><tr><th>Mã</th><th>Tên</th></tr></thead>';
          for (i in res) {
            t +=
              "<tr><td>" +
              res[i][0] +
              "</td>" +
              "<td>" +
              res[i][1] +
              "</td></tr>";
          }
          t += "</table>";
          $("#dvhc_code_result").html(t);
          break;
      }
    } else {
      $("#dvhc_code_result").html("<p>" + res[0][1] + "</p>");
    }
  } else {
    $("#dvhc_code_result").text("");
  }
}
