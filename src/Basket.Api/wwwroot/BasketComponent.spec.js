import { isHoverFunc }  from './BasketComponent';

test('isHoverFunc shoud return true only when point is hover', () => {

    const getBoundingClientRect = () => { left: 100, top: 100 };
    const size = { width: 200, height: 200 };
    let point = { x: 0, y: 0 };
    let isHover =  isHoverFunc(getBoundingClientRect, size)(point);

    expect(isHover).toBe(false);

    point = { x: 105, y: 110 };
    isHover = isHoverFunc(getBoundingClientRect, size)(point);

    expect(isHover).toBe(true);
});