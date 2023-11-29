// data (data giả để hiện giao diện thôi)
const newGamesList = [
    {
        gameID: 1,
        gameTitle: 'title1',
        type: 'type1',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 2,
        gameTitle: 'title2',
        type: 'type2',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 3,
        gameTitle: 'title3',
        type: 'type3',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 4,
        gameTitle: 'title4',
        type: 'type4',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 5,
        gameTitle: 'title5',
        type: 'type5',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 6,
        gameTitle: 'title6',
        type: 'type6',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 7,
        gameTitle: 'title7',
        type: 'type7',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 8,
        gameTitle: 'title8',
        type: 'type8',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 9,
        gameTitle: 'title9',
        type: 'type9',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 10,
        gameTitle: 'title10',
        type: 'type10',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 11,
        gameTitle: 'title11',
        type: 'type11',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 12,
        gameTitle: 'title12',
        type: 'type12',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 13,
        gameTitle: 'title13',
        type: 'type13',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 14,
        gameTitle: 'title14',
        type: 'type14',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 15,
        gameTitle: 'title15',
        type: 'type15',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 16,
        gameTitle: 'title16',
        type: 'type16',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 17,
        gameTitle: 'title17',
        type: 'type17',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 18,
        gameTitle: 'title18',
        type: 'type18',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 19,
        gameTitle: 'title19',
        type: 'type19',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 20,
        gameTitle: 'title20',
        type: 'type20',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 21,
        gameTitle: 'title21',
        type: 'type21',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 22,
        gameTitle: 'title22',
        type: 'type22',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 23,
        gameTitle: 'title23',
        type: 'type23',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 24,
        gameTitle: 'title24',
        type: 'type24',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 25,
        gameTitle: 'title25',
        type: 'type25',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 26,
        gameTitle: 'title26',
        type: 'type26',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 27,
        gameTitle: 'title27',
        type: 'type27',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 28,
        gameTitle: 'title28',
        type: 'type28',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 29,
        gameTitle: 'title29',
        type: 'type29',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 30,
        gameTitle: 'title30',
        type: 'type30',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 31,
        gameTitle: 'title31',
        type: 'type31',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    },
    {
        gameID: 32,
        gameTitle: 'title32',
        type: 'type32',
        rate: 4,
        imgPath: '/static/img/new1.jpg',
        downloadLinkPage: 'download.html',
        price: 100_000,
    }
]

// Varibles
let gamesArray = []

let array_l = 0 // tổng số game hiện có ở database
const displaySize = 8 // số game mình muốn hiển thị ở mỗi page
let startIdx = 1 // mốc đầu của số games ở 1 trang
let endIdx = 0 // mốc cuối của số trang nếu đúng thì là 8/16/24/32
let currentIdx = 0 // chỉ số hiện tại của page (hiện ở dưới), code thì để 0 cho dễ xử lý, UI thì là 1
let maxIdx = 0 // 32 games, mỗi page 8 thì sẽ có 4 page => max thì sẽ là 3

// selector của jquery
const pagi = $('.pagination')

// tính toán các biến để chuẩn bị cho load list item ra
const preLoadCalculation = () => {
    gamesArray = newGamesList
    array_l = gamesArray.length
    maxIdx = array_l / displaySize

    // chia cho 8 mà dư lớn hơn 0 thì tăng số trang thêm 1 để chứa game "dư ra"
    if (array_l % displaySize > 0) maxIdx++
}

const displayNewGamesList = () => {
    $('.category-content *').remove() // clear hết item của page hiện tại để load page mới nếu cần

    let startList = startIdx - 1  // nếu đúng thì sẽ là 0/8/16/...
    let endList = endIdx // 8/16/32/...
    
    // lặp qua số index để hiển thị games từng page
    for (let i = startList; i < endList; ++i) {
        let game = newGamesList[i]

        $('.category-content').append(`
            <div class="box">
                <img src=${game.imgPath} alt=""/>
                <div class="box_text">
                    <h2>${game.gameTitle}</h2>
                    <h3>${game.type}</h3>
                    <div class="rating-download">
                        <div class="rating">
                            <i class="bx bxs-star"></i>
                            <span>${game.rate}</span>
                        </div>
    
                        <a class="box-btn" asp-area="" asp-controller="DownloadPage" asp-action="DownloadGame">
                            <p>${game.price}đ</p>
                        </a>
                    </div>
                </div>
            </div>
        `)
    }
}

// highlight chỉ số page hiện tại
const highlightCurrentPage = () => {
    // tính khoảng index hiển thị games list
    startIdx = currentIdx * displaySize + 1
    endIdx = startIdx + displaySize - 1
    if (endIdx > array_l) endIdx = array_l

    let linksEle = document.querySelectorAll('.links button')

    if (currentIdx >= 0 && currentIdx < linksEle.length)
        linksEle.forEach(item => {
            item.classList.remove('active')
        })

    linksEle[currentIdx].classList.add('active')

    displayNewGamesList()
}

const onClickPreHandle = () => {
    if (currentIdx > 0) {
        currentIdx--
        highlightCurrentPage()
    }

    // diabled 2 cái mũi tên pre khi bấm tới page đầu
    if (currentIdx === 0) {
        document.querySelector('#startBtn').disabled = true
        document.querySelectorAll('.prevNext')[0].disabled = true
    }
}

const onClickIdxPagination = idx => {
    console.log(idx, maxIdx)
    
    if (idx === maxIdx) {
        idx--
        document.querySelector('#endBtn').disabled = true
        document.querySelectorAll('.prevNext')[1].disabled = true
    } else if (idx === 1) {
        idx--
        document.querySelector('#startBtn').disabled = true
        document.querySelectorAll('.prevNext')[0].disabled = true
    }  else idx--
    
    currentIdx = idx
    highlightCurrentPage()
}

const onClickNextHandle = () => {
    if (currentIdx < maxIdx) {
        currentIdx++
        highlightCurrentPage()
    }

    // disabled 2 cái mũi tên next khi tới page cuối
    if (currentIdx === maxIdx - 1) {
        document.querySelector('#endBtn').disabled = true
        document.querySelectorAll('.prevNext')[1].disabled = true
    }
}

const clickStartBtnHandle = () => {
    
}

const clickEndBtnHandle = () => {

}

// load element pagination
const displayPagination = () => {
    preLoadCalculation()

    $('.pagination *').remove() // clear pagination trước đã

    pagi.append(`
        <button class='button' id='startBtn' >
            <i class='bx bxs-chevrons-left'></i>
        </button>
        <button class='button prevNext' id='prev' onclick='onClickPreHandle()' >
            <i class='bx bxs-chevron-left'></i>
        </button>
    
        <div class="links"></div>
    `)

    for (let i= 1; i <= maxIdx; ++i)
        $('.links').append(
            `<button class='link' onclick='onClickIdxPagination(${i})'>${i}</button>`
        )
    
    pagi.append(`
        <button class='button prevNext' id='next' onclick='onClickNextHandle()'>
            <i class='bx bxs-chevron-right'></i>
        </button>
        <button class='button' id='endBtn'>
            <i class='bx bxs-chevrons-right'></i>
        </button>
    `)

    highlightCurrentPage()
}

displayPagination()