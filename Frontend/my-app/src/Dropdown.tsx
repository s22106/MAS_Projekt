import React, { useEffect, useState, useRef, RefObject } from "react";
import "./Dropdown.css";

const Dropdown = ({ placeholder, options, isSearchable, onChange }: { placeholder: string, options: string[], isSearchable: boolean, onChange: (value: string | null) => void }) => {
    const [showMenu, setShowMenu] = useState(false);
    const [selectedOption, setSelectedOption] = useState<string | null>(null);
    const [searchValue, setSearchValue] = useState<string>("");
    const searchRef = useRef<HTMLInputElement>() as RefObject<HTMLInputElement>;
    const inputRef = useRef<HTMLInputElement>();

    useEffect(() => {
        setSearchValue("");
        if (showMenu && searchRef.current) {
            searchRef.current.focus();
        }
    }, [showMenu]);


    useEffect(() => {
        const handler: EventListener = (e: Event) => {
            if (inputRef.current && !inputRef.current.contains(e.target as Node)) {
                setShowMenu(false);
            }
        };

        window.addEventListener("click", handler);
        return () => {
            window.removeEventListener("click", handler);
        };
    });

    const handleInputClick = (e: React.MouseEvent<HTMLInputElement>) => {
        setShowMenu(!showMenu);
    }

    const getDisplay = () => {
        if (selectedOption)
            return selectedOption;
        return placeholder;
    };

    const onItemClick = (option: string) => {
        setSelectedOption(option);
        onChange(option);
    };

    const isSelected = (option: string) => {
        if (!selectedOption)
            return false;
        return selectedOption === option;
    };

    const onSearch = (e: React.ChangeEvent<HTMLInputElement>) => {
        setSearchValue(e.target.value);
    };

    const getOptions = () => {
        if (!searchValue)
            return options;
        return options.filter((option) =>
            option.toLowerCase().indexOf(searchValue.toLowerCase()) >= 0);
    };

    return (
        <div className="dropdown-container">
            <div onClick={handleInputClick} className="dropdown-input">
                <div className="dropdown-selected-value">{getDisplay()}</div>
                {showMenu && (
                    <div className="menu-container">
                        <div className="dropdown-menu">
                            {isSearchable && (
                                <div className="search-box">
                                    <input onChange={onSearch} value={searchValue} ref={searchRef} />
                                </div>
                            )}
                            {getOptions().map((option, index) => (
                                <div onClick={() => onItemClick(option)}
                                    key={index}
                                    className={`dropdown-item ${isSelected(option) && "selected"}`}>
                                    {option}
                                </div>
                            ))}
                        </div>
                    </div>
                )}
            </div>
        </div>
    );
}

export default Dropdown;

//http://localhost:5185/api/TransitControler?startStation=Warszawa%20Wschodnia&endStation=Warszawa%20Zachodnia&date=2023-01-01
//http://localhost:5185/api/TransitController?startStation=Warszawa+Wschodnia&endStation=Warszawa+Zachodnia&date=2022-12-31T23:00:00.000Z